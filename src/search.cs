using System;

namespace Tubes2_DoiFinders{

    class folder {
        private string curDir = default!;
        private string endFile = default! ;
        public string getCurDir()
        {
            return curDir;
        }
        public void setCurDir(string newCurDir)
        {
            this.curDir = newCurDir; 
        }
        public string getEndFile()
        {
            return endFile;
        }
        public void setEndFile(string newEndFile)
        {
            this.endFile = newEndFile; 
        }
        public void inputSearch() 
        {
            Console.WriteLine("Enter directory root:");
            this.curDir = Console.ReadLine();
            while (!System.IO.Directory.Exists(this.curDir)) {
                Console.WriteLine("Directory not found! enter new directory: ");
                this.curDir = Console.ReadLine();
            }

            Console.WriteLine("Enter filename to search:");
            this.endFile = Console.ReadLine();
        }
    }

        class main {
        
        static void Main(string[] args) {

            folder start = new folder();
            start.inputSearch();

        }
    }
}