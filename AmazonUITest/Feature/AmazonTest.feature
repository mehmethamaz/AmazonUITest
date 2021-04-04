Feature: AmazonTest
	Müşteri olarak Amazon sitesinde Login olunur, arama yerine istenilen ürün ismi 
	yazılarak ürün sonuçlarında resimlerin yüklenip yüklenmediği 
	kontrol edilir.	Rastgele bir ürün sepete eklenilerek kontrol edilir.

Background:
    * 'Chrome' browser açılır
	* 'https://www.amazon.com.tr/' sitesine gidilir
	* Giriş Yap butonuna tıklanır
	* E-posta adresi 'mail' olarak girilir
	* Devam et butonuna tıklanır. 
	* Şifre 'password' olarak girilir.
	* Giriş yap butonuna tıklanır 
Scenario:  ProductControlandAddtoBasket
	* Arama yerine 'bilgisayar' yazılır.
	* Arama yap butonuna tıklanır.
	* Ürün görselleri kontrol edilir.
	* Rastgele ürüne tıklanır.
	* Ürün sepete eklenir.