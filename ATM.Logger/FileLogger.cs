namespace ATM.Logger
{
    public class FileLogger
    {
        private static FileLogger _logger;

        protected FileLogger()
        {

        }

        public static FileLogger GetLogger()
        {
            if (_logger == null)
            {
                _logger = new FileLogger();
            }

            return _logger;
        }

        public async Task<bool> Log(string log)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Log.txt", true))
                {
                    await sw.WriteLineAsync(DateTime.Now.ToString() + " " + log);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}