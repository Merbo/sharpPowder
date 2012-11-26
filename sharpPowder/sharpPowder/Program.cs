using System;

namespace sharpPowder
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Core core = new Core())
            {
                core.Run();
            }
        }
    }
#endif
}

