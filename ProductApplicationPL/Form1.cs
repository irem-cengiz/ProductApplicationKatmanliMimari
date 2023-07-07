using ProductApplicationBL.Repositories_Add_Update_Delete;
using ProductApplicationDAL.Context;
using ProductApplicationDAL.Entities;

namespace ProductApplicationPL
{
    public partial class Form1 : Form
    {
        private readonly ProductContextDb _db;  //dal ile dependincy kurduk
        private readonly Repository<Product> _repository;
        public Form1(ProductContextDb db)
        {
            InitializeComponent();
            //Repository ' yi kullan�rken , HANG� T�RDE OLACA�INI belirtmeliyiz.
            _db=db;
            _repository = new Repository<Product>(db);
            //fomun i�inde db koyduk repository i�ine de db koyduk.

            //REPOSITORY ��ER�S�NE YAZDIGIMIZ METOTLARI KULLANALIM

            //�r�n eklemek i�in:

            Product product = new Product();
            product.Name = "Ekmek";
            product.Price = 7;

            _repository.Insert(product);    //ekleme silme g�ncelleme i�lemlerimizi repository ile ya��yoruz.

            //guncelleme i�lemi

            var guncellenecekurun = _repository.GetById(1);
            guncellenecekurun.Name = "Patates";
            guncellenecekurun.Price = 15;
            _repository.Update();

            //silme i�lemi
            //iki sekilde silme metodu yapt�k delete ve deletebyid : 

            //silme1:

            var silinecekUrun= _repository.GetById(1);
            _repository.Delete(silinecekUrun);

            //silme2:
            _repository.DeleteById(1);


            //t�m �r�nleri getirme

            var tumUrunler = _repository.GetAll();

        }
    }
}