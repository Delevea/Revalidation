using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LitJson;

namespace Revalidation
{
    public partial class Form1 : Form
    {
        private List<string> modifyFiles = new List<string>();
        private List<string> newFiles = new List<string>();
        private Dictionary<string, string> currentDic = new Dictionary<string, string>();
        private Dictionary<string, string> historyDic = new Dictionary<string, string>();
        private bool isSaved = false;

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;         // 设置能报告进度更新
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;  //获取异步任务的进度百分比
            textFilesBox.Text = "索引文件生成中 - " + e.ProgressPercentage + "%";
            if (e.ProgressPercentage == 100)
            {
                CreateBtn.Enabled = true;
            }
            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button curr = (Button)sender;
            switch (curr.Name)
            {
                case "CheckBtn":    // 校验路径
                    FindFolderPath();
                    break;
                case "StandardBtn": // 索引文件
                    FindFilePath();
                    break;
                case "StartBtn":    // 开始校验
                    Revalidation();
                    break;
                case "ExportBtn":   // 导出
                    Export();
                    break;
                case "CreateBtn":   // 创建索引备份文件
                    CreateIndexFile();
                    break;
            }
        }

        /// <summary> 创建索引备份文件 </summary>
        private void CreateIndexFile()
        {
            try
            {
<<<<<<< HEAD
                GetFilesInfo(true);
            }
            catch (Exception)
            {
                // TODO: throw exception ...
                throw;
            }
        }

        private void GetFilesInfo(bool saved = false)
        {
            try
            {
                isSaved = saved;
=======
                CreateBtn.Enabled = false;
>>>>>>> 82b5c9e7cb4e036b6dedb42b0c8307b9c703237c
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception)
            {
                // TODO: throw exception ...
                throw;
            }
        }

        /// <summary> 选择文件夹路径 </summary>
        private void FindFolderPath()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "选择文件路径";
                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    textCheck.Text = dialog.SelectedPath;
                }           
            }
        }

        /// <summary> 选择索引文件 </summary>
        private void FindFilePath()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Json文件|*.json";
                dialog.Title = "选择版本索引文件";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        textStandard.Text = dialog.FileName;
                        StreamReader sr = new StreamReader(dialog.FileName, Encoding.UTF8);
                        historyDic = JsonMapper.ToObject<Dictionary<string, string>>(sr.ReadToEnd());
                        sr.Close();
                        tip1.ForeColor = Color.LightGreen;
                        tip1.Text = "载入成功";
                    }
                    catch (Exception)
                    {
                        tip1.ForeColor = Color.Red;
                        tip1.Text = "载入失败";
                    }
                }
            }
        }

        /// <summary> 从文件路径中截取文件名称（带后缀）</summary>
        private string GetFileShortName(string fileName)
        {
            string[] strs = fileName.Split('\\');
            return strs[strs.Length - 1];
        }

        /// <summary> 去重校验 </summary>
        private void Revalidation()
        {
            if (string.IsNullOrEmpty(textCheck.Text) || string.IsNullOrEmpty(textStandard.Text))
                return;

            if (currentDic.Count <= 0)
            {
                if (!Directory.Exists(textCheck.Text + @"\version") || !File.Exists(textCheck.Text + @"\version\FilesVersion.json"))
                {
                    textFilesBox.Text = "请先创建版本索引文件";
                    return;
                }
                StreamReader sr = new StreamReader(textCheck.Text + @"\version\FilesVersion.json", Encoding.UTF8);
                currentDic = JsonMapper.ToObject<Dictionary<string, string>>(sr.ReadToEnd());
                sr.Close();
            }
            modifyFiles.Clear();
            newFiles.Clear();

            foreach (var item in currentDic)
            {
                if (historyDic.ContainsKey(item.Key))
                {
                    if (historyDic[item.Key] != item.Value) // 修改过的文件
                    {
                        modifyFiles.Add(item.Key);
                    }
                }
                else    // 新增的文件
                {
                    newFiles.Add(item.Key);
                }
            }
            textFilesBox.Text = string.Empty;
            string tipStr = "校验完毕";
            if (modifyFiles.Count > 0)
            {
                tipStr += "," + modifyFiles.Count + "个文件进行了修改";
                foreach (var file in modifyFiles)
                {
                    textFilesBox.AppendText("Modify " + GetFileShortName(file) + "\r\n");
                }
            }
            else
            {
                tipStr += ",未发现更新文件";
            }

            if (newFiles.Count > 0)
            {
                tipStr += ",新增了" + newFiles.Count + "个文件";
                foreach (var file in newFiles)
                {
                    textFilesBox.AppendText("Add " + GetFileShortName(file) + "\r\n");
                }
            }
            else
            {
                tipStr += ",未发现新增文件";
            }

            textFilesBox.AppendText(tipStr);
        }

        /// <summary> 导出 </summary>
        private void Export()
        {
            try
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "选择导出路径";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string newPath = dialog.SelectedPath + @"\newFiles";
                        string modifyPath = dialog.SelectedPath + @"\modifyFiles";
                        if (newFiles.Count > 0)  
                        {
                            if (!Directory.Exists(newPath))
                            {
                                Directory.CreateDirectory(newPath);
                            }
                            foreach (var file in newFiles)
                            {
                                File.Copy(file, newPath + "\\" + GetFileShortName(file), true);
                            }
                        }

                        if (modifyFiles.Count > 0)
                        {
                            if (!Directory.Exists(modifyPath))
                            {
                                Directory.CreateDirectory(modifyPath);
                            }
                            foreach (var file in modifyFiles)
                            {
                                File.Copy(file, modifyPath + "\\" + GetFileShortName(file), true);
                            }
                        }
                        textFilesBox.AppendText("导出成功");
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            currentDic.Clear();
            FileStream stream = null;
            DirectoryInfo info = new DirectoryInfo(textCheck.Text);
            FileInfo[] files = info.GetFiles();
            int tempIdx = 0;
            for (int i = 0; i < files.Length; i++)
            {
                using (stream = File.Open(files[i].FullName, FileMode.Open))
                {
                    string md5str = FileHelper.ComputeFileMD5(stream);
                    currentDic.Add(files[i].Name, md5str);
                }
                tempIdx++;
                if (tempIdx >= 50)
                {
                    tempIdx = 0;
                    double val = Math.Round((double)i / (files.Length - 1), 2) * 100;
                    worker.ReportProgress(Convert.ToInt32(val));
                }
            }
            worker.ReportProgress(100);
           
            string str = JsonMapper.ToJson(currentDic);
            string dicPath = textCheck.Text + @"\version";
            if (!Directory.Exists(dicPath))
            {
                Directory.CreateDirectory(dicPath);
            }
            File.WriteAllText(dicPath + @"\FilesVersion.json", str, Encoding.UTF8);
        }
    }
}
