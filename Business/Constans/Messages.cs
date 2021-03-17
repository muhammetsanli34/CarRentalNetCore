using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";

        public static string UserAdded = "Kullanıcı kayıt oldu";
        public static string UserNameInvalid = "Kullanıcının adı veya soyadı geçersiz";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Kullanıcı silindi";
        public static string CustomerUpdated = "Kullanıcı güncellendi";

        public static string RentalAdded = "Sipariş eklendi";
        public static string RentalDeleted = "Sipariş silindi";
        public static string RentalUpdated = "Sipariş güncellendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";

        public static string MainMaintenance = "Sistem bakımda";

        public static string ImageAdded = "Resim eklendi";
        public static string ImageDeleted = "Resim silindi";
        public static string ImageLimitExceded = "Bir araba için en fazla 5 resim olabilir";

        public static string ThereIsNoPıcture = "Bu arabaya ait bir resim bulunmamaktadır";

        public static string ExistUser = "Kullanıcı zaten mevcut";

        public static string CarNotReturned = "Araba henüz teslim edilmemiş";

        public static string TokenCreated = "Token oluşturuldu";

        public static string EmailInvalid = "Geçersiz mail";
        public static string InvalidPassword = "Geçersiz şifre";
        public static string SuccessLogin = "Giriş başarılı";

        public static string AuthorizationDenied = "Bu işlemi yapabilmek için yetkiniz yok";
    }
}
