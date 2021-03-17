using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Personeller personeller = new Personeller();
            personeller.Add(new Personel { Id = 1, Adi = "Mami", SoyAdi = "Şanlı" });
            personeller.Add(new Personel { Id = 2, Adi = "Muhammet", SoyAdi = "Şanlı" });

            foreach (var personel in personeller)
            {
                Console.WriteLine(personel.Id);
            }
        }
    }
    class Personel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string SoyAdi { get; set; }
    }

    class Personeller : IEnumerable<Personel>
    {
        List<Personel> PersonelListesi = new List<Personel>();
        public void Add(Personel p)
        {
            PersonelListesi.Add(p);
        }
        //public IEnumerator<Personel> GetEnumerator()
        //{
        //    return PersonelListesi.GetEnumerator();
        //}
        public IEnumerator<Personel> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
