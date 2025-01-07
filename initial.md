mvc core teknolojisi ile bir proje oluşturmak istiyorum projenin adı alkonost olsun. projenin ui katmanı core mvc web olacak, mssql kullanacağım bunun için entity framework kullanacağım, model katmanı ile result modelleri karşılaştırmak için mediatr ve dataya erişmek için repository ve api katmanı istiyorum. bir web admin panel olacağı için uygun ui bileşenlerini proje eklemeni ve bununla beraber singleton vb. isterleri startup.cs içerisinde tanımlamanı ve panele erişimlerde admin, admin_it, kısıtlı yetkili ve hiç bir kayıt işlemi yapamayacak bir görüntüleme yetkisine sahip kullanıcı tipi olan bunun içinde identityleri oluşturup projeye implemente edebilir misin

CREATE TABLE Tours (
tour_id INT PRIMARY KEY AUTO_INCREMENT, -- Unique tour identifier
tour_name VARCHAR(255) NOT NULL, -- Name of the tour
tour_description TEXT, -- Description of the tour
start_date DATE NOT NULL, -- Start date of the tour
end_date DATE NOT NULL, -- End date of the tour
created_by_user_id INT NOT NULL, -- User who created the tour
last_modified TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, -- Last modified timestamp
status ENUM('active', 'inactive', 'completed') DEFAULT 'active', -- Tour status
location VARCHAR(255), -- Tour location (e.g., city, country)
price DECIMAL(10, 2) DEFAULT 0.00, -- Tour price (optional)
FOREIGN KEY (created_by_user_id) REFERENCES Users(user_id)
);

CREATE TABLE Travelers (
traveler_id INT PRIMARY KEY AUTO_INCREMENT, -- Unique traveler identifier
first_name VARCHAR(100) NOT NULL, -- Traveler's first name
last_name VARCHAR(100) NOT NULL, -- Traveler's last name
national_id VARCHAR(11) UNIQUE, -- National ID number (TC or equivalent)
passport_number VARCHAR(20) UNIQUE, -- Passport number
photo BLOB, -- Traveler's photo (binary format)
birth_date DATE NOT NULL, -- Traveler's birth date
email VARCHAR(255) UNIQUE NOT NULL, -- Traveler's email (unique)
email_verified BOOLEAN DEFAULT FALSE, -- Email verification status
phone_number VARCHAR(15), -- Traveler's phone number
address TEXT, -- Traveler's address
created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Record creation timestamp
updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, -- Last update timestamp
FOREIGN KEY (traveler_id) REFERENCES Users(user_id) -- Foreign key linking to users (if necessary)
);

CREATE TABLE Traveler_Tour (
traveler_id INT, -- Traveler's ID
tour_id INT, -- Tour's ID
participation_date DATE NOT NULL, -- Date the traveler participated in the tour
PRIMARY KEY (traveler_id, tour_id),
FOREIGN KEY (traveler_id) REFERENCES Travelers(traveler_id) ON DELETE CASCADE,
FOREIGN KEY (tour_id) REFERENCES Tours(tour_id) ON DELETE CASCADE
);

CREATE TABLE Payments (
payment_id INT PRIMARY KEY AUTO_INCREMENT, -- Unique payment identifier
traveler_id INT NOT NULL, -- ID of the traveler making the payment
tour_id INT NOT NULL, -- ID of the related tour
payment_date DATE NOT NULL, -- Date of the payment
amount DECIMAL(10, 2) NOT NULL, -- Payment amount
payment_method VARCHAR(50) NOT NULL, -- Payment method (e.g., Credit card, bank transfer)
payment_status ENUM('pending', 'completed', 'failed') DEFAULT 'pending', -- Payment status
created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Payment creation timestamp
updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, -- Last update timestamp
FOREIGN KEY (traveler_id) REFERENCES Travelers(traveler_id) ON DELETE CASCADE,
FOREIGN KEY (tour_id) REFERENCES Tours(tour_id) ON DELETE CASCADE
);

CREATE TABLE Users (
user_id INT PRIMARY KEY AUTO_INCREMENT, -- Unique user identifier
username VARCHAR(100) NOT NULL, -- Username
password_hash VARCHAR(255) NOT NULL, -- Hashed password for security
role ENUM('admin', 'authorized', 'lower_level') NOT NULL, -- User role (admin, authorized, or lower-level)
email VARCHAR(255) UNIQUE NOT NULL, -- User's email (unique)
email_verified BOOLEAN DEFAULT FALSE, -- Email verification status
phone_number VARCHAR(15), -- User's phone number
last_login TIMESTAMP, -- Timestamp of the last login
status ENUM('active', 'inactive') DEFAULT 'active', -- Account status
created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Record creation timestamp
updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP -- Last update timestamp
);

CREATE TABLE Traveler_Archive (
traveler_id INT, -- Traveler's ID
tour_id INT, -- Tour's ID
participation_date DATE NOT NULL, -- Date the traveler participated
created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Archive creation timestamp
PRIMARY KEY (traveler_id, tour_id),
FOREIGN KEY (traveler_id) REFERENCES Travelers(traveler_id),
FOREIGN KEY (tour_id) REFERENCES Tours(tour_id)
);

CREATE TABLE Tour_Permissions (
user_id INT, -- ID of the lower-level user
tour_id INT, -- ID of the related tour
permission_type ENUM('view', 'edit', 'delete') NOT NULL, -- Permission type granted
granted_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Timestamp when the permission was granted
PRIMARY KEY (user_id, tour_id),
FOREIGN KEY (user_id) REFERENCES Users(user_id),
FOREIGN KEY (tour_id) REFERENCES Tours(tour_id)
);

Ekstra Alanlar ve Yapılar:
E-posta doğrulama ve telefon numarası doğrulaması gibi ekstra güvenlik önlemleri.
Zaman damgaları (created_at, updated_at, last_modified) ekleyerek her kaydın ne zaman oluşturulduğu ve son güncellendiği izlenebilir.
Ödeme durumu ekleyerek, ödemelerin tamamlanıp tamamlanmadığını izleme.
Kullanıcı durumu ekleyerek, kullanıcıların aktif mi yoksa pasif mi olduğunu belirlemek.

Veritabanı İlişkileri:
FOREIGN KEY kısıtlamaları, veritabanındaki ilişkilerin bütünlüğünü sağlar.
ON DELETE CASCADE ve ON UPDATE CASCADE ilişkilerdeki değişikliklerin diğer tablolara yansımasını sağlar.
İndeksler:
Bazı kolonlarda, özellikle arama ve sorgulama performansı için indeksler eklenebilir. Örneğin:

email, national_id, passport_number gibi alanlara indeks eklemek, aramaları hızlandırır.

yukarıdaki yapı ile birlikte gezginlerin doğum günlerinde onlara doğum günü kutlama tebriği gönderen bir job, yeni bir tur eklendiğinde tur içerisine girilen gezginlerden ödeme alınacak tarihleri paneli yöneten userlara özet halinde atacak job ve gün içerisinde yapılan toplam ödeme bilgisini özet halinde sistem yetkililerine mail atacak job (bunun bir settings tablosu olmalı ve burada bu mailin kime gideceği yazmalı ve bu alanı sadece admin_it belirleyebilmeli), turlara kayıt edilen gezginlerin turlar için eksik belgeleri bulunması halinde userlara gezgin adı, gezgin detay sayfasına erişebileceği bir link ve eksik bilgi adını yazacak bir job yazar mısın?

Tüm bu projeyi oluşturup bana kod halini verir misin?
