using System;
using System.IO;

namespace Observers
{
    public class FileSaver : IObserver<AbstractStringSubject>
    {
        private string _fileName;
        
        public FileSaver(string p_fileName) =>
            _fileName = p_fileName;
        
        public void Update(AbstractStringSubject sub) =>
            File.AppendAllText(_fileName, sub.Item + "\n");
    }
}