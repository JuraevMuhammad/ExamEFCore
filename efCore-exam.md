# Супориши Техникӣ (ТЗ): Системаи API барои "Китобхонаи Донишгоҳ"

## 1. Ҳадафи лоиҳа
Сохтани **REST API** барои идоракунии раванди китобдиҳӣ дар китобхонаи донишгоҳ.

**Мақсадҳои таълимӣ:**
* Омӯзиши Entity Framework Core ва кор бо базаи маълумот.
* Татбиқи робитаҳои байни ҷадвалҳо: **One-to-Many** ва **One-to-One**.
* Сохтани мантиқи корӣ (Business Logic) дар сатҳи Service-ҳо.
* Истифодаи DTO (Data Transfer Objects) барои мубодилаи маълумот.

---

## 2. Сохтори Базаи Маълумот (Entity Models)

Дар система 6 ҷадвали асосӣ (Entity) мавҷуд аст:

### 1. Author (Муаллиф)
* **Id** (`int`, PK) — Идентификатор.
* **FullName** (`string`) — Ному насаб.
* **Country** (`string`) — Кишвар.
* **BirthDate** (`DateTime`) — Санаи таваллуд.

### 2. Genre (Жанр)
* **Id** (`int`, PK) — Идентификатор.
* **Name** (`string`) — Номи жанр (мас: "IT", "Classic").

### 3. Book (Китоб)
* **Id** (`int`, PK) — Идентификатор.
* **Title** (`string`) — Номи китоб.
* **Description** (`string`) — Тавсифи кӯтоҳ.
* **PublishedYear** (`int`) — Соли нашр.
* **Quantity** (`int`) — Шумораи нусхаҳо.
* **AuthorId** (`int`, FK) — Пайваст бо **Author**.
* **GenreId** (`int`, FK) — Пайваст бо **Genre**.

### 4. Student (Донишҷӯ)
* **Id** (`int`, PK) — Идентификатор.
* **FullName** (`string`) — Номи донишҷӯ.
* **Course** (`int`) — Курс (1, 2, 3 ё 4).
* **PhoneNumber** (`string`) — Рақами телефон.

### 5. LibraryCard (Билети Китобхона) — *Ҷадвали нав барои 1:1*
Ин ҷадвал маълумоти иловагии ҳуҷҷатиро нигоҳ медорад.
* **Id** (`int`, PK) — Идентификатор.
* **CardNumber** (`string`) — Рақами уникалии билет (мас: "LIB-2024-001").
* **IssueDate** (`DateTime`) — Санаи дода шудани билет.
* **StudentId** (`int`, FK, Unique) — Пайваст бо **Student**. (Ин майдон бояд уникалӣ бошад).

### 6. BorrowRecord (Сабти иҷора)
* **Id** (`int`, PK) — Идентификатор.
* **StudentId** (`int`, FK) — Пайваст бо **Student**.
* **BookId** (`int`, FK) — Пайваст бо **Book**.
* **BorrowDate** (`DateTime`) — Санаи гирифтан.
* **ReturnDate** (`DateTime?`) — Санаи баргардонидан.

---

## 3. Намудҳои Робитаҳо (Table Relationships)

Дар ин лоиҳа мо аз ду намуди робита истифода мебарем:

### А. Робитаи "Як ба Як" (One-to-One)
1.  **Student ↔ LibraryCard (1 : 1)**
    * **Тавсиф:** Як донишҷӯ як билети китобхона дорад ва як билет ба як донишҷӯ тааллуқ дорад.

### Б. Робитаи "Як ба Чанд" (One-to-Many)
2.  **Author ↔ Book (1 : N)**
    * Як муаллиф -> Чанд китоб.
3.  **Genre ↔ Book (1 : N)**
    * Як жанр -> Чанд китоб.
4.  **Student ↔ BorrowRecord (1 : N)**
    * Як донишҷӯ -> Чанд сабти иҷора (дар вақтҳои гуногун).
5.  **Book ↔ BorrowRecord (1 : N)**
    * Як китоб -> Чанд маротиба иҷора дода шудааст.

---

## 4. Вазифаҳои функсионалӣ (Services & Methods)

### I. AuthorService
1.  **CreateAuthor**: Илова кардани муаллиф.
2.  **UpdateAuthor**: Тағйир додани маълумот.
3.  **DeleteAuthor**: Ҳазфи муаллиф.
4.  **GetAuthorById**: Гирифтани муаллиф.
5.  **GetAllAuthors**: Рӯйхати муаллифон.
6.  **GetAuthorsWithBooks**: Гирифтани муаллифон бо китобҳояшон.
7.  **GetAuthorsByCountry**: Филтр бо кишвар.
8.  **GetAuthorsBornAfterYear**: Филтр бо сол.

### II. BookService
1.  **AddBook**: Иловаи китоб.
2.  **UpdateBook**: Тағйир додани китоб.
3.  **DeleteBook**: Ҳазфи китоб.
4.  **GetBookById**: Гирифтани китоб.
5.  **GetBooksWithAuthors**: Китобҳо бо муаллифонашон .
6.  **GetBooksWithGenres**: Китобҳо бо жанрашон.
7.  **GetBooksByGenreId**: Китобҳои як жанр.
8.  **GetBooksPublishedInYear**: Китобҳои соли муайян.

### III. StudentService (Бо логикаи 1:1)
1.  **RegisterStudent**: Қайди донишҷӯ (Ин метод бояд дарҳол `LibraryCard`-ро низ эҷод кунад ё методи алоҳида дошта бошад).
2.  **UpdateStudentProfile**: Тағйири маълумот.
3.  **DeleteStudent**: Ҳазфи донишҷӯ .
4.  **GetStudentById**: Гирифтани донишҷӯ.
5.  **GetStudentWithCard**: Гирифтани маълумоти донишҷӯ ҳамроҳ бо рақами билеташ.
6.  **GetAllStudentsWithCards**: Рӯйхати ҳамаи донишҷӯён бо билетҳояшон.
7.  **GetStudentsByCourse**: Филтр бо курс.
8.  **FindStudentByCardNumber**: Ҷустуҷӯи донишҷӯ аз рӯи рақами билеташ (Тавассути ҷадвали LibraryCard).

### IV. BorrowService
1.  **IssueBookToStudent**: Додани китоб.
2.  **ReturnBookFromStudent**: Баргардонидани китоб.
3.  **UpdateBorrowRecord**: Тағйири сабт.
4.  **DeleteBorrowRecord**: Ҳазфи сабт.
5.  **GetBorrowRecordById**: Гирифтани сабт.
6.  **GetAllBorrowsWithBooks**: Иҷораҳо бо китобҳо.
7.  **GetAllBorrowsWithStudents**: Иҷораҳо бо донишҷӯён .
8.  **GetCurrentActiveBorrows**: Қарзҳои фаъол (`ReturnDate == null`).


---

## 5. Сенарияи санҷиш (Test Scenario)

1.  Жанр ва Муаллиф илова кунед.
2.  Китоби "C# Programming" илова кунед.
3.  **Санҷиши 1:1**: Донишҷӯи нав "Ali Valiyev"-ро сабт кунед ва барояш дар ҷадвали `LibraryCard` билет созед (ё автоматӣ сохта шавад).
4.  Методи `GetStudentWithCard`-ро даъват кунед, то бубинед, ки оё рақами билет ҳамроҳи донишҷӯ меояд?
5.  Китобро ба ин донишҷӯ иҷора диҳед (`BorrowService`).
6.  Таърихи иҷораро тафтиш кунед.