using ProductApplicationDAL.Context;

namespace ProductApplicationPL
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
           //****** //veritaban�m�z�
           //temsil edecek nesnemizi burada olu�tural�m ve bundan sonra onu istedi�imiz her yerde kullanabilelim.
           ProductContextDb db = new ProductContextDb();    
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(db));
        }
    }
}