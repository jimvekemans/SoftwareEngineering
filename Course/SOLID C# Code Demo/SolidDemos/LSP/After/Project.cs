using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SolidDemos.LSP.After
{
    public class Project
    {
        public Collection<ProjectFile> AllFiles { get; set; }
        public Collection<WriteableFile> WriteableFiles { get; set; }

        public void LoadAllFiles()
        {
            foreach (ProjectFile file in AllFiles)
            {
                file.LoadFileData();
            }
        }

        public void SaveAllWriteableFiles()
        {
            foreach (WriteableFile file in WriteableFiles)
            {
                file.SaveFileData();
            }
        }
    }
}
