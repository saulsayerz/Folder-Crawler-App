using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Tubes2_DoiFinders{

    /// <summary>
    /// This folder class is what we use to save the CURRENT folder we're traversing.
    /// BFS and DFS algorithm are inside this class
    /// The attributes are :
    /// 1. curDir : a string to determine the current directory we are traversing
    /// 2. endFIle : a string, the name of the file we are trying to search for
    /// 3. found : a boolean, true if the file is found so traverse is stopped
    /// </summary>
    class folder {

        // Attributes: 
        private string curDir = default!; //tbh gatau knp harus = default!, tapi di komputerku kalau gk ada itu error
        private string endFile = default! ;
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
            while (!System.IO.Directory.Exists(this.curDir)) {
                Console.WriteLine("Directory not found! enter new directory: ");
                setCurDir(Console.ReadLine());
            }

            Console.WriteLine("Enter filename to search:");
            setEndFile(Console.ReadLine());
        }

        //To chose DFS or BFS algorithm
        public int chooseAlgorithm()
        {
            Console.WriteLine("\nChoose the algorithm to find the file: ");
            Console.WriteLine("1. For DFS (default)");
            Console.WriteLine("2. For BFS ");
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }

        public void checkFiles(){
            string[] listOfFiles = Directory.GetFiles(this.curDir);
            string namafile = null;
            foreach (var item in listOfFiles) 
            {
                namafile = Path.GetFileName(item);
                if (namafile == this.endFile) 
                {
                    this.found = true;
                    Console.WriteLine(item);
                    break;
                }
            }
        }

        //Search for the file using the DFS algorithm.
        public Boolean DFS(){

            // Check the current path first. Does it have the file we are searching for?
            this.checkFiles();

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
        public Boolean BFS(){
            //Check the start directory, does it have the file we're searching for?
            this.checkFiles();
            
            //In case the file is not found, iterate for every subdirectory using BFS traverse
            string[] listOfSubDir = Directory.GetDirectories(this.curDir);
            string tempStartDir = this.curDir;

            while (!this.found && listOfSubDir.Any())
            {
                this.setCurDir(listOfSubDir[0]);
                this.checkFiles();
                listOfSubDir = listOfSubDir.Concat(Directory.GetDirectories(this.curDir)).ToArray();
                listOfSubDir = listOfSubDir.Where(path => path != listOfSubDir[0]).ToArray(); // Remove the first path on the list

            }

            this.setCurDir(tempStartDir); // to reset the startDir the way it was
           
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

            int choice = start.chooseAlgorithm();
            if (choice == 2)
            {
                found = start.BFS();
            }
            else 
            {
                found = start.DFS();
            }
        }
    }*/
}