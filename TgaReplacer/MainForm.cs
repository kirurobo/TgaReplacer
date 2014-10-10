using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TgaReplacer
{
    public partial class MainForm : Form
    {
        private byte[] rawDll;
        private byte[] rawTga;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void buttonSelectBinaryFile_Click(object sender, EventArgs e)
        {
            openFileDialogTargetBinary.FileName = textBoxBinaryFile.Text;
            DialogResult res = openFileDialogTargetBinary.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                textBoxBinaryFile.Text = openFileDialogTargetBinary.FileName;
            }
        }

        private void buttonSelectTgaFile_Click(object sender, EventArgs e)
        {
            openFileDialogTga.FileName = textBoxTgaFile.Text;
            DialogResult res = openFileDialogTga.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                textBoxTgaFile.Text = openFileDialogTga.FileName;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // DLLファイルが空白
            if (textBoxBinaryFile.Text.Length < 1)
            {
                toolStripStatusLabel.Text = "書き換え対象のDLLを指定して下さい";
                return;
            }

            // TGAファイルが空白
            if (textBoxTgaFile.Text.Length < 1)
            {
                toolStripStatusLabel.Text = "TGA画像ファイルを指定して下さい";
                return;
            }

            // DLLファイルの存在確認
            if (!File.Exists(textBoxBinaryFile.Text))
            {
               toolStripStatusLabel.Text = "書き換え対象ファイルが存在しません";
                return;
            }

            // TGAファイルの存在確認
            if (!File.Exists(textBoxTgaFile.Text))
            {
                toolStripStatusLabel.Text = "画像ファイルが存在しません";
                return;
            }

            // 処理前の読込
            if (LoadBinaryFile())
            {
                // 終了メッセージ
                toolStripStatusLabel.Text = "バイナリファイル読込完了";

                if (LoadTgaFile())
                {
                    if (Convert())
                    {
                        // 読込みと変換の終了メッセージはConvert()中で表示される

                        if (Save())
                        {
                            // 保存終了メッセージ
                            toolStripStatusLabel.Text = "保存しました";
                        }
                        else
                        {
                            // 保存時エラー
                            toolStripStatusLabel.Text = "保存されませんでした";
                        }
                    }
                    else
                    {
                        // 変換時のエラーは Convert() 中で表示される
                    }
                }
                else
                {
                    // 終了メッセージ
                    toolStripStatusLabel.Text = "画像ファイル読込エラー";
                }
            }
            else
            {
                // 終了メッセージ
                toolStripStatusLabel.Text = "バイナリファイル読込エラー";
            }
        }

        /// <summary>
        /// 変換処理。失敗したときはデータは保証しない。
        /// </summary>
        /// <returns>成功すればtrue</returns>
        private bool Convert()
        {
            if (rawDll == null || rawTga == null) return false;

            int convertedCount = 0;
            int start = 0;
            int end = -1;
            while (true) {
                start = FindHeader(end + 1);
                if (start < 0)
                {
                    break;
                }

                end = FindFooter(start + 1);
                if (end < 0)
                {
                    toolStripStatusLabel.Text = "バイナリファイル中でTGA画像の終端が見つかりません";
                    return false;
                }

                if ((end - start + 1) < rawTga.Length)
                {
                    toolStripStatusLabel.Text = "TGA画像の容量が大きすぎます";
                    return false;
                }

                // 差し替え処理
                int index = start;
                foreach (byte dat in rawTga)
                {
                    rawDll[index] = dat;
                    index++;
                }
                convertedCount++;
            }

            // 一つも画像が見つからなかった
            if (convertedCount < 1)
            {
                toolStripStatusLabel.Text = "バイナリファイル中で対応するTGA画像が見つかりません";
                return false;
            }

            // 変換数を表示
            toolStripStatusLabel.Text = convertedCount.ToString() + "件の画像を変換しました";

            return true;
        }

        /// <summary>
        /// 変換後のバイナリファイルを保存
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            if (rawDll == null) return false;

            string path = textBoxBinaryFile.Text;
            string backupPath = path + ".bak";
            string tmpPath = path + ".tmp";

            // バックアップファイルが既存ならばバックアップしない
            if (File.Exists(backupPath))
            {
                DialogResult result = MessageBox.Show("バックアップが存在するため、新たにバックアップは作成しません" + Environment.NewLine + "本当に書き換えますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
                backupPath = null;  // バックアップが既存ならばバックアップを作成しない
            }
            else
            {
                DialogResult result = MessageBox.Show("本当に書き換えますか？" + Environment.NewLine + "元のファイルは .bak として保存されます", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            // 一時ファイルに保存
            File.WriteAllBytes(tmpPath, rawDll);

            // 一時ファイルを元のファイルと置き換え
            File.Replace(tmpPath, path, backupPath);

            return true;
        }

        /// <summary>
        /// 書き換え対象のバイナリファイルを読み込み、画像があれば表示
        /// </summary>
        /// <returns></returns>
        private bool LoadBinaryFile()
        {
            rawDll = null;

            try
            {
                rawDll = File.ReadAllBytes(textBoxBinaryFile.Text);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 差し替えする画像ファイルを読み込み
        /// </summary>
        /// <returns></returns>
        private bool LoadTgaFile()
        {
            try
            {
                rawTga = File.ReadAllBytes(textBoxTgaFile.Text);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 1024×512 TGA画像のヘッダーらしき並びを探す。
        /// </summary>
        /// <param name="startIndex">検索を開始するバイト位置</param>
        /// <returns>見つかった位置。見つからなければ -1</returns>
        private int FindHeader(int startIndex)
        {
            if (rawDll == null) return -1;

            // ヘッダー。これと見比べる。ただし3文字目は10(0x0A)でも通す。
            byte[] header = { 0, 0, 2, 0,  0, 0, 0, 0,  0, 0, 0, 0,  0, 4, 0, 2,  32};

            for (int currentIndex = startIndex; currentIndex <= (rawDll.Length - header.Length); currentIndex++)
            {
                bool unmatch = false;
                for (int headerIndex = 0; headerIndex < header.Length; headerIndex++)
                {
                    byte dat = rawDll[currentIndex + headerIndex];
                    if (dat != header[headerIndex] && (headerIndex != 2 || dat != 0x0A))
                    {
                        unmatch = true;
                        break;
                    }
                }
                if (!unmatch) return currentIndex;    // 見つかった
            }
            return -1;
        }

        /// <summary>
        /// TGA画像のフッターを探して最後のインデックスを返す。
        /// </summary>
        /// <param name="startIndex">検索を開始するバイト位置</param>
        /// <returns>見つかった範囲の終端位置。見つからなければ -1</returns>
        private int FindFooter(int startIndex)
        {
            if (rawDll == null) return -1;

            // フッター。これと見比べる。
            string footerString = "TRUEVISION-XFILE.\0";
            byte[] footer = System.Text.Encoding.ASCII.GetBytes(footerString);

            for (int currentIndex = startIndex; currentIndex <= (rawDll.Length - footer.Length); currentIndex++)
            {
                bool unmatch = false;
                for (int footerIndex = 0; footerIndex < footer.Length; footerIndex++)
                {
                    byte dat = rawDll[currentIndex + footerIndex];
                    if (dat != footer[footerIndex])
                    {
                        unmatch = true;
                        break;
                    }
                }
                if (!unmatch) return (currentIndex + footer.Length - 1);    // 見つかった
            }
            return -1;
        }


        /// <summary>
        /// ファイルをドラッグされてきたときはマウスカーソルを替える
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileNameBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// ファイルをテキストボックスにドロップされた場合はそのパスを入れる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileNameBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (sender is TextBox)
            {
                ((TextBox)sender).Text = files[0];
            }
        }
    }
}
