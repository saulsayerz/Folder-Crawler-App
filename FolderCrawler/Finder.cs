using System;
using System.IO;

namespace Finder
{

    /// <summary>
    /// This folder class is what we use to save the CURRENT folder we're traversing.
    /// BFS and DFS algorithm are inside this class
    /// The attributes are :
    /// 1. curDir : a string to determine the current directory we are traversing
    /// 2. endFIle : a string, the name of the file we are trying to search for
    /// 3. found : a boolean, true if the file is found so traverse is stopped
    /// </summary>
    class folder
    {

        // Attributes: 
        private string curDir = default!; //tbh gatau knp harus = default!, tapi di komputerku kalau gk ada itu error
        private string endFile = default!;
        private Boolean found = false; //kondisi awal --> file belum ditemukan

        // Getter 
        public string getCurDir()
        {
            return curDir;
        }

        public string getEndFile()
        {
            return endFile;
        }

        // Setter 
        public void setCurDir(string newCurDir)
        {
            this.curDir = newCurDir;
        }

        public void setEndFile(string newEndFile)
        {
            this.endFile = newEndFile;
        }

        // To get input for the attributes
        public void inputSearch()
        {
            Console.WriteLine("Enter directory root:");
            this.curDir = Console.ReadLine();
            while (!System.IO.Directory.Exists(this.curDir))
            {
                Console.WriteLine("Directory not found! enter new directory: ");
                setCurDir(Console.ReadLine());
            }

            Console.WriteLine("Enter filename to search:");
            setEndFile(Console.ReadLine());
        }

        //Search for the file using the DFS algorithm.
        public Boolean DFS()
        {

            // Check the current path first. Does it have the file we are searching for?
            string[] listOfFiles = Directory.GetFiles(this.curDir);
            string namafile = null;
            foreach (var item in listOfFiles)
            {
                namafile = Path.GetFileName(item);
                if (namafile == this.endFile)
                {
                    found = true;
                    Console.WriteLine(item);
                    break;
                }
            }

            // If file is not present in the current path, we continue to traverse for each subdirectory.
            if (!this.found)
            {
                string[] listOfSubDir = Directory.GetDirectories(this.curDir);
                folder subfolder = new folder();
                subfolder.setEndFile(this.endFile);
                foreach (var item in listOfSubDir)
                {
                    if (this.found)
                    {
                        break;
                    }
                    subfolder.setCurDir(item);
                    this.found = subfolder.DFS();
                }
            }
            return this.found;
        }
    }

    /*class main {

    /// <summary>
    /// Main class to run, implement, test, and debug the search algorithm
    /// </summary>
    static void Main(string[] args) {
        Boolean found = false;;
        folder start = new folder();
        start.inputSearch();
        found = start.DFS();

    }
}*/
}