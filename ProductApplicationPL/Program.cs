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
           //****** //veritabanımızı
           //temsil edecek nesnemizi burada oluşturalım ve bundan sonra onu istediğimiz her yerde kullanabilelim.
           ProductContextDb db = new ProductContextDb();    
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(db));
        }
    }
}