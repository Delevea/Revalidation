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
        private Dictionary<string, string> historyDic = new Dictionary<string, string>();


        public Form1()
        {
            InitializeComponent();
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
                Dictionary<string, string> dic = GetFilesInfo();
                string str = JsonMapper.ToJson(dic);
                string dicPath = textCheck.Text + @"\version";
                if (!Directory.Exists(dicPath))
                {
                    Directory.CreateDirectory(dicPath);
                }
                File.WriteAllText(dicPath + @"\FilesVersion.json", str, Encoding.UTF8);   
            }
            catch (Exception)
            {
                // TODO: throw exception ...
                throw;
            }
        }

        private Dictionary<string, string> GetFilesInfo()
        {
            try
            {
                Dictionary<string, string> fileDic = new Dictionary<string, string>();
                FileStream stream = null;
                DirectoryInfo info = new DirectoryInfo(textCheck.Text);
                foreach (var item in info.GetFiles())
                {
                    using (stream = File.Open(item.FullName, FileMode.Open))
                    {
                        string md5str = FileHelper.ComputeFileMD5(stream);
                        fileDic.Add(item.FullName, md5str);
                    }
                }
                // TODO: Thread code ...
                return fileDic;
            }
            catch (Exception ex)
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
                        tips.Visible = true;
                        tips.ForeColor = Color.LightGreen;
                        tips.Text = "载入成功";
                    }
                    catch (Exception e)
                    {
                        throw;
                        // TODO: throw exception ...
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

            Dictionary<string, string> currentDic = GetFilesInfo();
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
            if (modifyFiles.Count > 0)
            {
                foreach (var file in modifyFiles)
                {
                    textFilesBox.AppendText("Modify " + GetFileShortName(file) + "\r\n");
                }
            }

            if (newFiles.Count > 0)
            {
                foreach (var file in newFiles)
                {
                    textFilesBox.AppendText("Add " + GetFileShortName(file) + "\r\n");
                }
            }
        }

        /// <summary> 导出 </summary>
        private void Export()
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
                }
            }

        }
    }
}
