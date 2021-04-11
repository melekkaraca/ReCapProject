using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Eklendi.";
        public static string Updaded = "Güncellendi.";
        public static string Deleted = "Silindi.";
        public static string NameInValid = "İsim geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string Listed = "Listelendi.";
        public static string Rental = "Kiralandı.";
        public static string Untenantable = "Kiralanamaz.";

        public static string CarImageLimit = "Maksimum fotograf sayısına ulaşıldı";
        public static string AuthorizationDenied = "İşlem yetkiniz bulunmamaktadır";

        public static string UserRegistered = "Kullanıcı kaydedildi";

        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessFullLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı";
        public static string AccessTokenCreated = "Erişim anahtarı oluşturuldu";
        public static string CarNotRentDate = "Araç başkası tarafından kiralanmış.";
        public static string PaymentReceived = "Ödeme alındı.";
        public static string PaymentCouldNotBeReceived = "Ödeme alınamadı";
        public static string FindexPointsAreNotEnough = "Findex puanı yeterli değil";
    }
}
