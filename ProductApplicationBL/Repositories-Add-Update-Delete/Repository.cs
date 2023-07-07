using Microsoft.EntityFrameworkCore;
using ProductApplicationDAL;
using ProductApplicationDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplicationBL.Repositories_Add_Update_Delete
{

    //BÜTÜN CLASSLAR(VARLIKLAR) İÇİN GENEL BİR REPOSITORY YAZACAĞIZ.
    // T dediğimiz bütün varlıkları temsi L ediyor. Dolayısıyla biz bu repository'yi kullanırken T yerine İstediğimiz
    //class tipinde bir varlığı gönderebılırız. Böylece ıçerısıne gönderdiğimiz türde bır reposıtory olmuş olacak.
   // örn: T yerine product gönderdiğimiz zaman aşağıdaki metotlar product için çalışacak. T yerine başka bir sınıf gönderdiğimiz zaman  aşağıdaki metotlar o sınıf için çalışacak.
    public class Repository<T> where T : class
        //<T>-tüm varlıkları temsil eder. varlıklarımın tipi class olsun dedim. tüm classları temsil eder. **generic yapı
    {
        private readonly ProductContextDb _db;

        // ProductContextDb db = new ProductContextDb(); //dal içinde biz bl içindeyiz bunu tanımıyor.Dependencies kısmında bağı kurmalıyız.sürekli newlemek yerine tek db üzerinden gitmek için ctor içerisinde tanımladık.

        private DbSet<T> entities;
        public Repository(ProductContextDb db)
        {
            _db= db;   
            entities=_db.Set<T>();   
            //_db.Product.
            //_db.YeniClass demek yerine entities. diyerek kullanabilmek için T tipinde DbSet oluşturduk.       
        }
        //Insert,Delete,Update,GetSll,GetById

        public void Insert (T entity) 
        {
            entities.Add(entity);
            _db.SaveChanges();
        }

        public void Update () 
        {
            _db.SaveChanges();
        }

        public void Delete (T entity)  //direkt gönderileni siler
        {  
            entities.Remove(entity);
            _db.SaveChanges ();
        }
        public void DeleteById(int id) //o id ye ait olanı siler
        {
            var varlik = entities.Find(id);
            if (varlik != null)
            {
                entities.Remove(varlik);
                _db.SaveChanges();
            }          

        }

        public IQueryable<T> GetAll()  //neden koleksiyon kullandık cünkü tüm varlıkları getirsin istiyoruz.
        {
            return entities;
        }

        public T GetById(int id)
        {
            var varlik= entities.Find(id);
            if (varlik==null)
            {
                throw new Exception("Invalid entity");
            }
            return varlik;
              
        }
    }
}
