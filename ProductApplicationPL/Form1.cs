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
            //Repository ' yi kullanýrken , HANGÝ TÜRDE OLACAÐINI belirtmeliyiz.
            _db=db;
            _repository = new Repository<Product>(db);
            //fomun içinde db koyduk repository içine de db koyduk.

            //REPOSITORY ÝÇERÝSÝNE YAZDIGIMIZ METOTLARI KULLANALIM

            //ürün eklemek için:

            Product product = new Product();
            product.Name = "Ekmek";
            product.Price = 7;

            _repository.Insert(product);    //ekleme silme güncelleme iþlemlerimizi repository ile yaðýyoruz.

            //guncelleme iþlemi

            var guncellenecekurun = _repository.GetById(1);
            guncellenecekurun.Name = "Patates";
            guncellenecekurun.Price = 15;
            _repository.Update();

            //silme iþlemi
            //iki sekilde silme metodu yaptýk delete ve deletebyid : 

            //silme1:

            var silinecekUrun= _repository.GetById(1);
            _repository.Delete(silinecekUrun);

            //silme2:
            _repository.DeleteById(1);


            //tüm ürünleri getirme

            var tumUrunler = _repository.GetAll();

        }
    }
}