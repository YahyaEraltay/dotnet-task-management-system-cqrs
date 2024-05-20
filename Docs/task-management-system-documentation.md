# Görev Yönetim Sistemi

Bu dokümantasyon, **Görev Yönetim Sistemi** projesinin teknik detaylarını ve kullanım kılavuzunu içermektedir.

## Giriş

Bu proje, bir görev yönetim sistemi oluşturmayı amaçlamıştır. Görev yönetim sistemi, bir organizasyonun veya bir grup insanın projelerini, görevlerini ve iş akışlarını düzenlemek ve takip etmesini kolaylaştırmayı hedeflemiştir. Bu sistem ekipler arasında işbirliğini kolaylaştırır, görevlerin atanmasını, izlenmesini ve tamamlanmasını sağlar.

Görev Yönetim Sistemine kullanıcılar e-posta ve şifreleriyle birlikte giriş yaparlar. Giriş yapan kullanıcılar için bir JWT oluşturulur. Bu sayede sistemdeki tüm endpoint' leri kullanabilirler. Sisteme kayıtlı tüm görevleri görüntüleyebilecekleri bir endpoint bulunmaktadır. Burada görevlerin şu bilgileri bulunur:

- **Atanan Kişinin Adı ve Soyadı**
- **E-posta Adresi**
- **Departman Bilgisi**
- **İş ve Görev Tanımı**
- **Atama Yapan Kişi**
- **Görev Durumu**
  - *Beklemede*
  - *Onaylandı*
  - *Reddedildi*

Görevin detaylarını görüntülemek için bir detay endpointi bulunmaktadır. Sisteme giriş yapan kullanıcı, görevi kendisi oluşturmuşsa güncelleme veya silme işlemlerini gerçekleştirebilir. Kullanıcılar sadece kendilerine atanmış görevleri de listeleyebilirler. Burada kendisine atanan görevi onaylayabilir veya reddedebilir. Yeni görev ekleme işlemi de yine sisteme giriş yapan kullanıcılar tarafından yapılabilir.  Ayrıca, kendi profil bilgilerini görüntüleyebilirler.


Proje, .NET 6.0 ve RESTful API kullanılarak geliştirilmiştir. Clean Architecture prensipleri doğrultusunda tasarlanmış olup, CQRS (Command Query Responsibility Segregation) mimarisi kullanılarak yapılandırılmıştır. Ayrıca DTO (Data Transfer Objects) ve JWT (JSON Web Token) kimlik doğrulama mekanizması da projede yer almaktadır. Projenin veri tabanı Code First yaklaşımıyla oluşturulmuştur.

### Teknolojiler ve Mimariler

- **.NET 6.0:** Projenin temel geliştirme platformu olarak kullanılmıştır.
- **RESTful API:** Uygulama, REST prensiplerine uygun olarak API'ler aracılığıyla iletişim sağlar.
- **Clean Architecture:** Projede Clean Architecture prensipleri takip edilerek modüler bir yapı oluşturulmuştur.
- **CQRS:** Command ve query sorumluluğu ayrımı prensibine dayanan bir mimari yaklaşım kullanılmıştır.
- **DTO:** DTO' lar, verilerin farklı sistemler veya bileşenler arasında aktarılmasını kolaylaştırmak için kullanılmıştır.
- **JWT:** JSON Web Token, kimlik doğrulama ve yetkilendirme için kullanılmıştır.
- **Code First:** Veritabanı yapıları Code First yaklaşımıyla oluşturulmuştur. Bu yöntem, projenin var olan entity'lerine dayanarak veri tabanı tablolarını oluşturur ve günceller.
- **Dependency Injection:** Dependency Injection, uygulamanın bağımlılıklarını yönetmek için kullanılan bir tasarım desenidir. 


## Domain Katmanı

Domain katmanı, uygulamanın çekirdek yapılarını ve temel veri nesnelerini içerir. Bu katman, veri tabanı tabloları ve ilişkilerine karşılık gelen entity sınıflarını içerir. Department, User ve ToDoTask gibi temel entity sınıfları, uygulamanın ana veri yapılarını oluşturur. Her bir entity sınıfı, özelliklerini ve ilişkilerini tanımlar. Clean Architecture prensiplerine uygun bir şekilde tasarlanmıştır.


### Department Entity

Department entity'si, projenin departman bilgilerini temsil eder. Clean Architecture prensiplerine uygun olarak domain katmanında yer alır ve veri tabanı işlemlerini gerçekleştiren repository sınıfı tarafından kullanılır.

- **`Id`:** Departmanın benzersiz kimliğini temsil eden bir GUID.
- **`DepartmentName`:** Departmanın adını temsil eder.

**İlişkiler**

- Department nesnesi bir veya daha fazla kullanıcı (User) ile ilişkilendirilebilir.
- Department nesnesi bir veya daha fazla görev (ToDoTask) ile ilişkilendirilebilir.

### User Entity

User entity'si, projenin kullanıcı bilgilerini temsil eder. Clean Architecture prensiplerine uygun olarak domain katmanında yer alır ve veri tabanı işlemlerini gerçekleştiren repository sınıfı tarafından kullanılır.

- **`Id`:** Kullanıcının benzersiz kimligini temsil eden bir GUID.
- **`UserName`:** Kullanıcının kullanıcı adını temsil eder.
- **`UserEmail`:** Kullanıcının e-posta adresini temsil eder.
- **`UserPassword`:** Kullanıcının şifresini temsil eder.
- **`PhoneNumber`:** Kullanıcının telefon numarasını temsil eder.
- **`UserTitle`:** Kullanıcının pozisyonunu temsil eder.

**İlişkiler**

- User entity' si sadece bir departman (Department) ile ilişkilendirilebilir.
- User entity' si bir veya daha fazla görev (ToDoTask) ile ilişkiledirilebilir.


### ToDoTask Entity

ToDoTask entity'si, projenin görev bilgilerini temsil eder. Bu sınıf, Clean Architecture prensiplerine uygun olarak domain katmanında yer alır ve veri tabanı işlemlerini gerçekleştiren repository sınıfı tarafından kullanılır.

- **`Id`:** Görevin benzersiz kimliğini temsil eden bir GUID.
- **`ToDoTaskName`:** Görevin adını temsil eder.
- **`ToDoTaskDescription`:** Görevin açıklamasını temsil eder.
- **`ToDoTaskDate`:** Görevin oluşturulma tarihini temsil eder.
- **`AssignedDepartmentName`:** Görevi oluşturan kişinin ilişkili olduğu departmanı temsil eder.
- **`CreatorUser`:** Görevi oluşturan kullanıcıyı temsil eder.
- **`AssignedUser`:** Göreve atanmış kullanıcıyı temsil eder.
- **`Status`:** Görevin durumunu temsil eder (Beklemede, Onaylanmış, Reddedilmiş).

**İlişkiler**

- ToDoTask entity'si, sadece bir departman ile ilişkilendirilebilir.
- ToDoTask entity'si, bir CreatorUser (oluşturan kullanıcı) ile ilişkilendirilmiştir. Görevi oluşturan kullanıcıyı belirtir.
- ToDoTask entity'si, bir AssignedUser (atanmış kullanıcı) ile ilişkilendirilmiştir. Göreve atanmış kullanıcıyı belirtir.


## Infrastructure Katmanı

Infrastructure katmanı, uygulamanın alt yapısal bileşenlerini içerir. Bu katman, veri tabanı bağlantıları, veri tabanı işlemleri için repository sınıfları, dış servislerle iletişim için HTTP istemcileri ve diğer sistem bileşenlerini barındırır. Ayrıca, DTO'lar ve veri tabanı şemalarını güncellemek için kullanılan migration kodlarını içeren klasörler de bulunur. Bu katman, uygulamanın temel veri işlemlerini gerçekleştirirken aynı zamanda dış dünya ile iletişimini sağlar.

### RelationalDB 

---

#### ApplicationDbContext 

`ApplicationDbContext`, Entity Framework Core tarafından sağlanan `DbContext` sınıfından türetilmiş bir sınıftır. Bu sınıf, Görev Yönetim Sistemi projesinin temel veri tabanı işlemlerini gerçekleştirmek için kullanılır.

#### Özellikler

- **Departments**: Departmanları temsil eden bir `DbSet`.
- **Users**: Kullanıcıları temsil eden bir `DbSet`.
- **ToDoTasks**: Görevleri temsil eden bir `DbSet`.

#### Metotlar

- **ApplicationDbContext**: Bağlantı dizesi üzerinden bir veritabanı bağlantısı oluşturur. Bağlantı dizesi, uygulamanın hangi veritabanına erişeceğini belirtir.
- **BuildDbContextOptions**: Veritabanı bağlantısı için `DbContextOptions` örneğini oluşturan bir statik metottur. Bağlantı dizesi parametresi alır ve SQL Server veritabanı kullanılarak bir `DbContextOptions` nesnesi oluşturur.
- **OnModelCreating**: Veritabanı modeli oluşturma işlemi için override edilmiş bir metottur. Bu metod, `ToDoTask` varlık tipi için ilişki kurallarını tanımlar. ToDoTask sınıfında iki tane User nesnesi kullanıldığından dolayı bu metota ihtiyaç duyulmuştur.

### Repository 

---

Repository klasörü, veri tabanından veri almak veya veri kaydetmek gibi işlemleri gerçekleştirmeye yarayan sınıfları içerir. Department, User ve ToDoTask için repository sınıfları ve bunların arayüzleri bulunur.

#### DepartmentRepository ve IDepartmentRepository

- **DepartmentRepository**: Departman varlık tipi için veri tabanı işlemlerini gerçekleştiren bir sınıftır.
- **IDepartmentRepository**: DepartmentRepository sınıfının arayüzüdür. Departman varlık tipi için kullanılacak işlemleri tanımlar.

#### Metotlar

- **Create**: Yeni bir departman oluşturmak için kullanılır. Parametre olarak bir `Department` nesnesi alır ve oluşturulan departmanın referansını döndürür.
- **Update**: Varolan bir departmanı güncellemek için kullanılır. Parametre olarak güncellenmiş `Department` nesnesini alır ve güncellenmiş departmanın referansını döndürür.
- **Delete**: Varolan bir departmanı silmek için kullanılır. Parametre olarak silinecek `Department` nesnesini alır ve silinen departmanın referansını döndürür.
- **GetById**: Belirli bir departmanın ID'sine göre departmanı alma işlemi için kullanılır. Parametre olarak bir `Guid` ID alır ve ilgili departmanın referansını döndürür.
- **All**: Tüm departmanları almak için kullanılır. Hiçbir parametre almaz ve tüm departmanların bir listesini döndürür.

#### UserRepository ve IUserRepository

- **UserRepository**: Kullanıcı varlık tipi için veri tabanı işlemlerini gerçekleştiren bir sınıftır.
- **IUserRepository**: UserRepository sınıfının arayüzüdür. User varlık tipi için kullanılacak işlemleri tanımlar.

#### Metotlar

- **Create**: Yeni bir kullanıcı oluşturmak için kullanılır. Parametre olarak bir `User` nesnesi alır ve oluşturulan kullanıcının referansını döndürür.
- **Update**: Varolan bir kullanıcıyı güncellemek için kullanılır. Parametre olarak güncellenmiş `User` nesnesini alır ve güncellenmiş kullanıcının referansını döndürür.
- **Delete**: Varolan bir kullanıcıyı silmek için kullanılır. Parametre olarak silinecek `User` nesnesini alır ve silinen kullanıcının referansını döndürür.
- **GetById**: Belirli bir kullanıcının ID'sine göre kullanıcıyı alma işlemi için kullanılır. Parametre olarak bir `Guid` ID alır ve ilgili kullanıcının referansını döndürür.
- **All**: Tüm kullanıcıları almak için kullanılır. Hiçbir parametre almaz ve tüm kullanıcıların bir listesini döndürür.
- **Login**: Kullanıcı oturumu açmak için kullanılır. Parametre olarak e-posta adresi ve şifre alır ve doğru kullanıcı bilgileriyle oturum açan kullanıcının referansını döndürür.
- **GetUserByEmail**: Belirli bir e-posta adresine sahip kullanıcıyı alma işlemi için kullanılır. Parametre olarak bir e-posta adresi alır ve ilgili kullanıcının e-posta adresini döndürür.

#### ToDoTaskRepository ve IToDoTaskRepository

- **ToDoTaskRepository**: ToDoTask varlık tipi için veri tabanı işlemlerini gerçekleştiren bir sınıftır.
- **IToDoTaskRepository**: ToDoTaskRepository sınıfının arayüzüdür. ToDoTask varlık tipi için kullanılacak işlemleri tanımlar.

#### Metotlar

- **Create**: Yeni bir görev oluşturmak için kullanılır. Parametre olarak bir `ToDoTask` nesnesi alır ve oluşturulan görevin referansını döndürür.
- **Update**: Varolan bir görevi güncellemek için kullanılır. Parametre olarak güncellenmiş `ToDoTask` nesnesini alır ve güncellenmiş görevin referansını döndürür.
- **Delete**: Varolan bir görevi silmek için kullanılır. Parametre olarak silinecek `ToDoTask` nesnesini alır ve silinen görevin referansını döndürür.
- **GetById**: Belirli bir görevin ID'sine göre görevi alma işlemi için kullanılır. Parametre olarak bir `Guid` ID alır ve ilgili görevin referansını döndürür.
- **All**: Tüm görevleri almak için kullanılır. Hiçbir parametre almaz ve tüm görevlerin bir listesini döndürür.
- **AssignedToDoTask**: Belirli bir kullanıcıya atanmış görevleri almak için kullanılır. Parametre olarak bir kullanıcı ID'si alır ve ilgili kullanıcıya atanmış tüm görevlerin bir listesini döndürür.
- **UpdateStatus**: Görevin durumunu güncellemek için kullanılır. Parametre olarak güncellenmiş `ToDoTask` nesnesini alır ve güncellenmiş görevin referansını döndürür.
- **CreatorUser**: Belirli bir görevi oluşturan kullanıcının ID'sini alma işlemi için kullanılır. Parametre olarak bir görevin ID'sini alır ve ilgili görevi oluşturan kullanıcının ID'sini döndürür.
- **AssignedUser**: Belirli bir göreve atanmış kullanıcının ID'sini alma işlemi için kullanılır. Parametre olarak bir görevin ID'sini alır ve ilgili göreve atanmış kullanıcının ID'sini döndürür.

### Service 

---

#### CurrentUserService ve ICurrentUserService

- **CurrentUserService**: Kullanıcının oturum bilgilerini alır ve bu bilgilere dayanarak sistemdeki mevcut kullanıcıyı belirlemek için kullanılır. 
- **ICurrentUserService**: CurrentUserService sınıfının arayüzüdür. 

#### Özellikler

- **_httpContextAccessor**: HTTP isteği ve yanıtı bilgilerine erişim sağlayan IHttpContextAccessor örneğini tutar.
- **_userRepository**: Kullanıcı bilgilerini veritabanından almak için IUserRepository bağımlılığını tutar.  

#### Metotlar

- **GetCurrentUser**: Mevcut kullanıcıyı belirlemek için kullanılır. HTTP isteği üzerinden kullanıcının kimlik bilgilerini alır, bu bilgileri kullanarak kullanıcıyı bulur ve ilgili kullanıcı bilgilerini döndürür. Eğer kullanıcı bulunamazsa, bir hata fırlatır.

### DTO' lar (Data Transfer Objects)

---

DTO' lar, farklı katmanlar arasında veri alışverişi için kullanılan veri transfer nesneleridir. Genellikle veritabanından alınan veya veritabanına kaydedilen verilerin taşınmasında kullanılırlar. Bu projede, DepartmentDTOs, UserDTOs ve ToDoTaskDTOs olmak üzere üç farklı klasörde DTO'lar bulunmaktadır. Her bir klasör, ilgili entity' ler (Department, User ve ToDoTask) için özel olarak tasarlanmış DTO'ları içerir.

### DepartmentDTOs

Departmanlarla ilgili veri transferi için kullanılan DTO' ları içerir. Her klasörün kendi içinde RequestModel ve ResponseModel sınfları bulunmaktadır.

- **AllDepartmentDTOs**

- **CreateDepartmentDTOs**

- **DeleteDepartmentDTOs**

- **GetByIdDepartmentDTOs**

- **UpdateDepartmentDTOs**

 
### UserDTOs

User ile ilgili veri transferi için kullanılan DTO' ları içerir. Her klasörün kendi içinde RequestModel ve ResponseModel sınfları bulunmaktadır.

- **AllUserDTOs**

- **CreateUserDTOs**

- **CurrentUserDTOs**

- **DeleteUserDTOs**

- **GetByIdUserDTOs**

- **LoginUserDTOs**

- **UpdateUserDTOs**


### ToDoTaskDTOs

ToDoTask ile ilgili veri transferi için kullanılan DTO' ları içerir. Her klasörün kendi içinde RequestModel ve ResponseModel sınfları bulunmaktadır.

- **AllToDoTaskDTOs**

- **AssignedToDoTaskDTOs**

- **CreateToDoTaskDTOs**

- **DeleteToDoTaskDTOs**

- **GetByIdToDoTaskDTOs**

- **UpdateStatusToDoTaskDTOs**

- **UpdateToDoTaskDTOs**


### Migration Klasörü

----

Migration klasörü, veri tabanı şemalarını güncellemek veya başlangıç şemalarını oluşturmak için kullanılan veri tabanı migration kodlarını içerir. Bu klasör, veri tabanı yapısını değiştiren her türlü işlemi temsil eder ve bu işlemler uygulama sürümüyle senkronize olmasını sağlar.


### Kullanılan NuGet Paketleri

---

- **Microsoft.AspNetCore.Http.Abstractions (2.1.1)**
- **Microsoft.EntityFrameworkCore (6.0.29)**
- **Microsoft.EntityFrameworkCore.Design (6.0.29)**
- **Microsoft.EntityFrameworkCore.SqlServer (6.0.29)**

## Application Katmanı

Application katmanında,  CQRS (Command Query Responsibility Segregation) mimarisi kullanılmıştır. Bu mimari, komutları (commands) ve sorguları (queries) ayrı işlemler olarak ele alarak birbirinden bağımsızlaştırır.Örneğin, kullanıcı oluşturma işlemi için bir komut (command) ve bu komutun işlenmesi için bir handler bulunmaktadır. Ayrıca, kullanıcıları getirme işlemi için bir sorgu (query) ve bu sorgunun işlenmesi için bir handler bulunmaktadır. Böylelikle, yazılan kodun daha modüler ve daha kolay yönetilebilir olması sağlanır.

Bu işlemleri yönetmek için MediatR yapısı kullanılmıştır. MediatR, CQRS mimarisini uygulamak için kullanılan bir kütüphanedir. Bu kütüphane, komutları ve sorguları işleyen handler'ları yönetir ve işlem sonuçlarını döndürür.

Ayrıca, JWT (JSON Web Token) token'ları bu katmanda üretilir. JWT token'ları, kimlik doğrulama ve yetkilendirme için kullanılır. Kullanıcı doğrulama işlemi başarılı olduğunda, JWT token'ı üretilir ve istemciye gönderilir. Bu token, istemcinin gelecekteki isteklerini doğrulamak için kullanılır ve kullanıcının kimliğini doğrulamak için gerekli bilgileri içerir.

### Department 

---

### Commands

Department üzerinde gerçekleştirilebilecek komutlar bu bölümde bulunmaktadır.

#### Create

- **Handler:** `CreateDepartmentHandler`
- **Request:** `CreateDepartmentRequest`
- **Response:** `CreateDepartmentResponse`

Bu komut, yeni bir departman oluşturmak için kullanılır. `CreateDepartmentRequest` sınıfı, oluşturulacak departmanın bilgilerini içerir. Bu komutun işlenmesi sonucunda `CreateDepartmentResponse` sınıfıyla işlem sonucu ve oluşturulan departmanın bilgileri döndürülür. Komutun işlenmesi, `CreateDepartmentHandler` tarafından gerçekleştirilir. 

#### Update

- **Handler:** `UpdateDepartmentHandler`
- **Request:** `UpdateDepartmentRequest`
- **Response:** `UpdateDepartmentResponse`

Bu komut, varolan bir departmanı güncellemek için kullanılır. `UpdateDepartmentRequest` sınıfı, güncellenecek departmanın kimliğini ve yeni bilgilerini içerir. İşlem sonucu ve güncellenen departmanın bilgileri `UpdateDepartmentResponse` sınıfıyla döndürülür. Komutun işlenmesi, `UpdateDepartmentHandler` tarafından gerçekleştirilir.

#### Delete

- **Handler:** `DeleteDepartmentHandler`
- **Request:** `DeleteDepartmentRequest`
- **Response:** `DeleteDepartmentResponse`

Bu komut, varolan bir departmanı silmek için kullanılır. `DeleteDepartmentRequest` sınıfı, silinecek departmanın kimliğini içerir. İşlem sonucu `DeleteDepartmentResponse` sınıfıyla döndürülür. Komutun işlenmesi, `DeleteDepartmentHandler` tarafından gerçekleştirilir.

### Queries

Department üzerinde gerçekleştirilebilecek sorgular bu bölümde bulunmaktadır.

#### All

- **Handler:** `AllDepartmentHandler`
- **Response:** `AllDepartmentResponse`
- **Request:** `AllDepartmentRequest` 

Bu sorgu, tüm departmanların listesini getirmek için kullanılır. MediatR yapısını kullanabilmek için boş bir `AllDepartmentRequest` sınıfı oluşturulmuştur. İşlem sonucu ve departman listesi `AllDepartmentResponse` sınıfıyla döndürülür. Komutun işlenmesi, `AllDepartmentHandler` tarafından gerçekleştirilir.

#### Detail

- **Handler:** `DetailDepartmentHandler`
- **Request:** `DetailDepartmentRequest`
- **Response:** `DetailDepartmentResponse`

Bu sorgu, belirli bir departmanın bilgilerini getirmek için kullanılır. `DetailDepartmentRequest` sınıfı, istenen departmanın kimliğini içerir. İşlem sonucu ve departman bilgileri `DetailDepartmentResponse` sınıfıyla döndürülür. Komutun işlenmesi, `DetailDepartmentHandler` tarafından gerçekleştirilir.

### User

---

### Commands

User üzerinde gerçekleştirilebilecek komutlar bu bölümde bulunmaktadır.

#### Create

- **Handler:** `CreateUserHandler`
- **Request:** `CreateUserRequest`
- **Response:** `CreateUserResponse`

Bu komut, yeni bir kullanıcı oluşturmak için kullanılır. `CreateUserRequest` sınıfı, oluşturulacak kullanıcının bilgilerini içerir. Bu komutun işlenmesi sonucunda `CreateUserResponse` sınıfıyla işlem sonucu ve oluşturulan kullanıcının bilgileri döndürülür. Komutun işlenmesi, `CreateUserHandler` tarafından gerçekleştirilir.

#### Update

- **Handler:** `UpdateUserHandler`
- **Request:** `UpdateUserRequest`
- **Response:** `UpdateUserResponse`

Bu komut, varolan bir kullanıcıyı güncellemek için kullanılır. `UpdateUserRequest` sınıfı, güncellenecek kullanıcının kimliğini ve yeni bilgilerini içerir. İşlem sonucu ve güncellenen kullanıcının bilgileri `UpdateUserResponse` sınıfıyla döndürülür. Komutun işlenmesi, `UpdateUserHandler` tarafından gerçekleştirilir.

#### Delete

- **Handler:** `DeleteUserHandler`
- **Request:** `DeleteUserRequest`
- **Response:** `DeleteUserResponse`

Bu komut, varolan bir kullanıcıyı silmek için kullanılır. `DeleteUserRequest` sınıfı, silinecek kullanıcının kimliğini içerir. İşlem sonucu `DeleteUserResponse` sınıfıyla döndürülür. Komutun işlenmesi, `DeleteUserHandler` tarafından gerçekleştirilir. Komutun işlenmesi, `DeleteUserHandler` tarafından gerçekleştirilir.

#### Login

- **Handler:** `LoginUserHandler`
- **Request:** `LoginUserRequest`
- **Response:** `LoginUserResponse`

Bu komut, kullanıcı girişi yapmak için kullanılır. `LoginUserRequest` sınıfı, kullanıcının kimlik bilgilerini içerir. İşlem sonucu ve oturum açan kullanıcının bilgileri `LoginUserResponse` sınıfıyla döndürülür. Komutun işlenmesi, `LoginUserHandler` tarafından gerçekleştirilir.

### Queries

User üzerinde gerçekleştirilebilecek sorgular bu bölümde bulunmaktadır.

#### All

- **Handler:** `AllUserHandler`
- **Request:** `AllUserRequest`
- **Response:** `AllUserResponse`

Bu sorgu, tüm kullanıcıların listesini getirmek için kullanılır. MediatR yapısını kullanabilmek için boş bir `AllUserRequest` sınıfı oluşturulmuştur. İşlem sonucu ve kullanıcı listesi `GetAllUsersResponse` sınıfıyla döndürülür. Komutun işlenmesi, `LoginUserHandler` tarafından gerçekleştirilir.

#### Detail

- **Handler:** `DetailUserHandler`
- **Request:** `DetailUserRequest`
- **Response:** `DetailUserResponse`

Bu sorgu, belirli bir kullanıcının bilgilerini getirmek için kullanılır. `DetailUserRequest` sınıfı, istenen kullanıcının kimliğini içerir. İşlem sonucu ve kullanıcı bilgileri `DetailUserResponse` sınıfıyla döndürülür. Komutun işlenmesi, `DetailUserHandler` tarafından gerçekleştirilir.


### ToDoTask

---

### Commands

ToDoTask üzerinde gerçekleştirilebilecek komutlar bu bölümde bulunmaktadır.

#### Create

- **Handler:** `CreateToDoTaskHandler`
- **Request:** `CreateToDoTaskRequest`
- **Response:** `CreateToDoTaskResponse`

Bu komut, yeni bir görev oluşturmak için kullanılır. `CreateToDoTaskRequest` sınıfı, oluşturulacak görevin bilgilerini içerir. Bu komutun işlenmesi sonucunda `CreateToDoTaskResponse` sınıfıyla işlem sonucu ve oluşturulan görevin bilgileri döndürülür. Komutun işlenmesi, `CreateToDoTaskHandler` tarafından gerçekleştirilir.

#### Update

- **Handler:** `UpdateToDoTaskHandler`
- **Request:** `UpdateToDoTaskRequest`
- **Response:** `UpdateToDoTaskResponse`

Bu komut, varolan bir görevi güncellemek için kullanılır. `UpdateToDoTaskRequest` sınıfı, güncellenecek görevin kimliğini ve yeni bilgilerini içerir. İşlem sonucu ve güncellenen görevin bilgileri `UpdateToDoTaskResponse` sınıfıyla döndürülür. Komutun işlenmesi, `UpdateToDoTaskHandler` tarafından gerçekleştirilir.

#### Delete

- **Handler:** `DeleteToDoTaskHandler`
- **Request:** `DeleteToDoTaskRequest`
- **Response:** `DeleteToDoTaskResponse`

Bu komut, varolan bir görevi silmek için kullanılır. `DeleteToDoTaskRequest` sınıfı, silinecek görevin kimliğini içerir. İşlem sonucu `DeleteToDoTaskResponse` sınıfıyla döndürülür. Komutun işlenmesi, `DeleteToDoTaskHandler` tarafından gerçekleştirilir.

#### Status

- **Handler:** `StatusToDoTaskHandler`
- **Request:** `StatusToDoTaskRequest`
- **Response:** `StatusToDoTaskResponse`

Bu komut, bir görevin durumunu güncellemek için kullanılır. `StatusToDoTaskRequest` sınıfı, güncellenecek görevin kimliğini ve yeni durumunu içerir. İşlem sonucu ve güncellenen görevin bilgileri `StatusToDoTaskResponse` sınıfıyla döndürülür. Komutun işlenmesi, `StatusToDoTaskHandler` tarafından gerçekleştirilir.

### Queries

ToDoTask üzerinde gerçekleştirilebilecek sorgular bu bölümde bulunmaktadır.

#### All

- **Handler:** `AllToDoTaskHandler`
- **Request:** `AllToDoTaskRequest`
- **Response:** `AllToDoTaskResponse`

Bu sorgu, tüm görevlerin listesini getirmek için kullanılır. MediatR yapısını kullanabilmek için boş bir `AllToDoTaskRequest` sınıfı oluşturulmuştur. İşlem sonucu ve görev listesi `AllToDoTaskResponse` sınıfıyla döndürülür. Komutun işlenmesi, `AllToDoTaskHandler` tarafından gerçekleştirilir.

#### Detail

- **Handler:** `DetailToDoTaskHandler`
- **Request:** `DetailToDoTaskRequest`
- **Response:** `DetailToDoTaskResponse`

Bu sorgu, belirli bir görevin bilgilerini getirmek için kullanılır. `DetailToDoTaskRequest` sınıfı, istenen görevin kimliğini içerir. İşlem sonucu ve görev bilgileri `DetailToDoTaskResponse` sınıfıyla döndürülür. Komutun işlenmesi, `DetailToDoTaskHandler` tarafından gerçekleştirilir.

#### AssignedToDoTask

- **Handler:** `AssignedToDoTaskHandler`
- **Request:** `AssignedToDoTaskRequest`
- **Response:** `AssignedToDoTaskResponse`

Bu sorgu, belirli bir kullanıcıya atanmış görevlerin listesini getirmek için kullanılır. MediatR yapısını kullanabilmek için boş bir `AllToDoTaskRequest` sınıfı oluşturulmuştur. İşlem sonucu ve görev listesi `AssignedToDoTaskResponse` sınıfıyla döndürülür. Komutun işlenmesi, `AssignedToDoTaskHandler` tarafından gerçekleştirilir.
Handler tarafında sisteme giriş yapan kullanıcının kimliğini alır ve bu kullanıcıya atanmış görevleri getirir.


### Auth

---

Bu klasör, JWT token üretimiyle ilgili işlemleri gerçekleştiren sınıfları içerir.

#### IGenerateJwtToken
- Bu arayüz, JWT token üretmek için gerekli olan GenerateToken metodunu tanımlar.

#### GenerateJwtToken
- Bu sınıf, JWT token üretimi için gerekli metodu içerir. GenerateToken metodu, bir LoginUserResponse nesnesi alır ve bu nesneye göre bir JWT token oluşturur. Token oluşturulurken, konfigürasyon dosyasından alınan ayarlar kullanılır. Token'ın geçerlilik süresi, alıcısı, yayıncısı ve imzalama yöntemi gibi bilgiler belirlenir. Bu şekilde, GenerateJwtToken sınıfı, JWT token üretimi işlemlerini gerçekleştirir.


### Kullanılan NuGet Paketleri

---

- **MediatR (9.0.0)**
- **Microsoft.AspNetCore.Http.Abstractions (2.1.1)**

## API Katmanı

API katmanı, uygulamanın dış dünyayla etkileşimini sağlar. DepartmentController, UserController ve ToDoTaskController' ları bulunmaktadır. Böylelikle ilgili HTTP isteklerini yönetir ve uygulamanın sunduğu işlevselliği tanımlayan endpoint'leri sağlar.  

Ayrıca, uygulamanın yapılandırma ayarlarını içeren appsettings.json dosyası bulunur. Bu dosyada, DefaultConnection anahtarında veritabanı bağlantı dizesi ve JWT için audience, issuer ve key gibi gerekli güvenlik ayarları bulunur.

Program.cs dosyası, uygulamanın giriş noktasıdır. Burada uygulamanın başlatılması için gerekli olan yapılandırma ayarları ve servis bağımlılıkları tanımlanır. appsettings.json dosyasından yapılandırma ayarlarının yüklenmesi ve uygulamanın çalıştırılması işlemleri bu dosyada gerçekleştirilir. 

### Department Controller

---

Department Controller, departmanlarla ilgili HTTP isteklerini yönetir. 

#### Özellikler

- **Authorize**: Controller' a gelen isteklerin yetkilendirme işleminden geçmesi gerektiğini belirtir.
- **Route**: Controller' ın kök yolunu (`api/Department`) belirtir.
- **ApiController**: Bu sınıfın bir API kontrolcüsü olduğunu belirtir.

#### Metotlar

#### Create

Bu metot, yeni bir departman oluşturmak için kullanılır. HTTP POST isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `CreateDepartmentRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. Oluşturulan departmanın bilgileri içeren `CreateDepartmentResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: POST
- **Route**: api/Department/Create

#### Update

Bu metot, var olan bir departmanı güncellemek için kullanılır. HTTP PUT isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `UpdateDepartmentRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. Güncellenen departmanın bilgilerini içeren `UpdateDepartmentResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: PUT
- **Route**: api/Department/Update

#### Delete

Bu metot, var olan bir departmanı silmek için kullanılır. HTTP DELETE isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `DeleteDepartmentRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. İşlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilen `DeleteDepartmentResponse` nesnesi, departmanın başarıyla silinip silinmediğini belirten değer ve işlem sonucuyla ilgili mesaj gönderir.

- **HTTP Metodu**: DELETE
- **Route**: api/Department/Delete

#### Detail

Bu metot, belirli bir departmanın detaylarını almak için kullanılır. HTTP GET isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `DetailDepartmentRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. Departmanın detaylarını içeren `DetailDepartmentResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: GET
- **Route**: api/Department/Detail

#### All

Bu metot, tüm departmanları listelemek için kullanılır. HTTP GET isteği ile çalışır. MediatR aracılığıyla gönderilen `AllDepartmentRequest` nesnesi, ilgili işleyiciye iletilir. Tüm departmanların listesini içeren `AllDepartmentResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: GET
- **Route**: api/Department/All

### User Controller

---

User Controller, kullanıcılarla ilgili HTTP isteklerini yönetir. 

#### Özellikler

- **Authorize**: Controller' a gelen isteklerin yetkilendirme işleminden geçmesi gerektiğini belirtir.
- **Route**: Controller' ın kök yolunu (`api/User`) belirtir.
- **ApiController**: Bu sınıfın bir API kontrolcüsü olduğunu belirtir.

#### Metotlar

#### Create

Bu metot, yeni bir kullanıcı oluşturmak için kullanılır. HTTP POST isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `CreateUserRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. Oluşturulan kullanıcının bilgilerini içeren `CreateUserResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: POST
- **Route**: api/User/Create

#### Update

Bu metot, var olan bir kullanıcıyı güncellemek için kullanılır. HTTP PUT isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `UpdateUserRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. Güncellenen kullanıcının bilgilerini içeren `UpdateUserResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: PUT
- **Route**: api/User/Update

#### Delete

Bu metot, var olan bir kullanıcıyı silmek için kullanılır. HTTP DELETE isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `DeleteUserRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. İşlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilen `DeleteUserResponse` nesnesi, kullanıcının başarıyla silinip silinmediğini belirten değer ve işlem sonucuyla ilgili mesaj gönderir.

- **HTTP Metodu**: DELETE
- **Route**: api/User/Delete

#### Detail

Bu metot, belirli bir kullanıcının detaylarını almak için kullanılır. HTTP GET isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `DetailUserRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. Kullanıcının detaylarını içeren `DetailUserResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: GET
- **Route**: api/User/Detail

#### All

Bu metot, tüm kullanıcıları listelemek için kullanılır. HTTP GET isteği ile çalışır. MediatR aracılığıyla gönderilen `AllUserRequest` nesnesi, ilgili işleyiciye iletilir. Tüm kullanıcıların listesini içeren `AllUserResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: GET
- **Route**: api/User/All

#### Login

Bu metot, kullanıcı girişi yapmak için kullanılır. HTTP POST isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `LoginUserRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. Kullanıcı girişi başarılı olduğunda HTTP 200 OK yanıtıyla istemciye bir JWT (Json Web Token) döndürülür. Bu metotun kullanılabilmesi için AllowAnonymous attribute eklenmiştir.

- **HTTP Metodu**: POST
- **Route**: api/User/Login

#### GetCurrentUser

Bu metot, sisteme giriş yapan kullanıcının bilgilerini getirmek için kullanılır. HTTP GET isteği ile çalışır. Kullanıcı bilgilerini içeren `CurrentUserDTO` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: GET
- **Route**: api/User/GetCurrentUser

### ToDoTask Controller

---

ToDoTask Controller, görevlerle ilgili HTTP isteklerini yönetir. 

#### Özellikler

- **Authorize**: Controller' a gelen isteklerin yetkilendirme işleminden geçmesi gerektiğini belirtir.
- **Route**: Controller' ın kök yolunu (`api/ToDoTask`) belirtir.
- **ApiController**: Bu sınıfın bir API kontrolcüsü olduğunu belirtir.

#### Metotlar

#### Create

Bu metot, yeni bir görev oluşturmak için kullanılır. HTTP POST isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `CreateToDoTaskRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. Oluşturulan görevin bilgilerini içeren `CreateToDoTaskResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: POST
- **Route**: api/ToDoTask/Create

#### Update

Bu metot, var olan bir görevi güncellemek için kullanılır. HTTP PUT isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `UpdateToDoTaskRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. Güncellenen görevin bilgilerini içeren `UpdateToDoTaskResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: PUT
- **Route**: api/ToDoTask/Update

#### Delete

Bu metot, var olan bir görevi silmek için kullanılır. HTTP DELETE isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `DeleteToDoTaskRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. İşlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilen `DeleteToDoTaskResponse` nesnesi, görevin başarıyla silinip silinmediğini belirten değer ve işlem sonucuyla ilgili mesaj gönderir.

- **HTTP Metodu**: DELETE
- **Route**: api/ToDoTask/Delete

#### Detail

Bu metot, belirli bir görevin detaylarını almak için kullanılır. HTTP GET isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `DetailToDoTaskRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. Görevin detaylarını içeren `DetailToDoTaskResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: GET
- **Route**: api/ToDoTask/Detail

#### All

Bu metot, tüm görevleri listelemek için kullanılır. HTTP GET isteği ile çalışır. MediatR aracılığıyla gönderilen `AllToDoTaskRequest` nesnesi, ilgili işleyiciye iletilir. Tüm görevlerin listesini içeren `AllToDoTaskResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: GET
- **Route**: api/ToDoTask/All

#### AssignedTasks

Bu metot, giriş yapan kullanıcıya atanmış görevleri listelemek için kullanılır. HTTP GET isteği ile çalışır. MediatR aracılığıyla gönderilen `AssignedToDoTaskRequest` nesnesi, ilgili işleyiciye iletilir. Kullanıcıya atanmış görevlerin listesini içeren `AssignedToDoTaskResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: GET
- **Route**: api/ToDoTask/AssignedTasks

#### TaskStatus

Bu metot, bir görevin durumunu güncellemek için kullanılır. HTTP POST isteği ile çalışır. İstek gövdesinden (`FromBody`) alınan `StatusToDoTaskRequest` nesnesi, MediatR aracılığıyla ilgili işleyiciye iletilir. Görevin güncellenmiş durumunu içeren `StatusToDoTaskResponse` nesnesi, işlem başarılı olduğunda HTTP 200 OK yanıtıyla istemciye gönderilir.

- **HTTP Metodu**: POST
- **Route**: api/ToDoTask/TaskStatus


### appsettings.json

---

Bu dosya, uygulamanın yapılandırma ayarlarını içerir. AllowedHosts bölümü, tüm istemcilerin kabul edildiği ana bilgisayar adresini belirtir. Veri tabanı bağlantı dizesi ise `ConnectionStrings` altında bulunur. DefaultConnection anahtarında, SQL Server'a yapılan bir bağlantı örneği verilmiştir. Bu bağlantı dizesi, sunucu adresi (Server), veri tabanı adı (Database), kullanıcı adı (User), ve şifre (Password) gibi bilgileri içerir.


### Program.cs 

---

Program.cs projenin başlangıcını yapılandırmak için kullanılır.

#### Hizmetlerin Kaydedilmesi

- `ApplicationDbContext` ve `IGenerateJwtToken` gibi bağımlılıkların bir örneği konteynere eklenir. Bu, bu servislerin uygulama boyunca kullanılabilir hale getirilmesini sağlar.

#### JSON Serialization Ayarları

- JSON işlemleri için yapılandırmalar eklenmesi:

#### Kimlik Doğrulama ve Yetkilendirme Ayarları

- Gelen JWT token'ın geçerliliği ve güvenilirliği doğrulanır.

#### Swagger/OpenAPI Desteği

- API belgelendirmesi ve testi için Swagger UI ve Swagger JSON endpoint'leri oluşturulur.

#### Scoped Servislerin Kaydedilmesi

- Her HTTP isteği için yeni bir örnek oluşturulan servislerdir.

#### MediatR Entegrasyonu

- MediatR kullanarak isteklerin ve komutların işlenmesi sağlanır.

#### HTTP İsteği Yönlendirme

- Gelen HTTP isteklerinin, uygun Controller eşleştirmelerine göre yönlendirilmesi.

#### Middleware'lerin Kullanılması

- Kimlik doğrulama ve yetkilendirme middleware'lerinin eklenmesi.

#### Uygulamanın Başlatılması

- Uygulamanın başlatılmasını ve gelen HTTP isteklerini işlemesini sağlar.


### Kullanılan NuGet Paketleri

---

- **MediatR.Extensions.Microsoft.DependencyInjection (9.0.0)**
- **Microsoft.AspNetCore.Authentication.JwtBearer (6.0.29)**
- **Microsoft.EntityFrameworkCore (6.0.29)**
- **Microsoft.EntityFrameworkCore.Design (6.0.29)**
- **Microsoft.EntityFrameworkCore.Tools (6.0.29)**
- **Swashbuckle.AspNetCore (6.5.0)**