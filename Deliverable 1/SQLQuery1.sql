CREATE TABLE Customer (
  customer_id INT PRIMARY KEY,
  fname VARCHAR(25),
  lname VARCHAR(25),
  phone_number VARCHAR(15),
  organisation VARCHAR(50)
);

CREATE TABLE Booking (
  id INT PRIMARY KEY,
  amount_of_students INT,
  customer_id INT,
  /*FOREIGN KEY (customer_id) REFERENCES Customer*/
);

CREATE TABLE Course (
  course_name VARCHAR(50) PRIMARY KEY,
  duration_minutes INT
);

CREATE TABLE Class (
  class_name VARCHAR(50),
  class_date DATE,
  class_time TIME,
  cost DECIMAL(10, 2),
  number_of_students INT,
  course_name VARCHAR(50),
  PRIMARY KEY (class_name, class_date, class_time),
  FOREIGN KEY (course_name) REFERENCES Course
);

CREATE TABLE Student (
  student_id INT PRIMARY KEY,
  fname VARCHAR(25),
  lname VARCHAR(25),
  phone_number INT
);

CREATE TABLE StudentCompletesCourse (
  student_id INT,
  course_name VARCHAR(50),
  completion_status VARCHAR(20),
  certificate_expiry_date DATE,
  PRIMARY KEY (student_id, course_name),
  FOREIGN KEY (student_id) REFERENCES Student,
  FOREIGN KEY (course_name) REFERENCES Course,
  check(completion_status in('completed', 'not completed'))
);

CREATE TABLE StudentTakesClass (
  student_id INT,
  class_name VARCHAR(50),
  class_date DATE,
  class_time TIME,
  attendance VARCHAR(20),
  PRIMARY KEY (student_id, class_name, class_date, class_time),
  FOREIGN KEY (student_id) REFERENCES Student(student_id),
  FOREIGN KEY (class_name, class_date, class_time) REFERENCES Class ,
  check(attendance in('attended', 'absent'))
);

CREATE TABLE BookingForClass (
  booking_id INT,
  class_name VARCHAR(50),
  class_date DATE,
  class_time TIME,
  number_of_students INT,
  PRIMARY KEY (booking_id, class_name, class_date, class_time),
  /*FOREIGN KEY (booking_id) REFERENCES Booking,*/
  FOREIGN KEY (class_name, class_date, class_time) REFERENCES Class
);

CREATE TABLE BookingForStudent (
  student_id INT,
  booking_id INT,
  PRIMARY KEY (student_id, booking_id),
  FOREIGN KEY (student_id) REFERENCES Student,
  /*FOREIGN KEY (booking_id) REFERENCES Booking*/
);

CREATE TABLE Account (
  username VARCHAR(50) PRIMARY KEY,
  street_number INT,
  street VARCHAR(25),
  postcode INT,
  town_city VARCHAR(50)
);

CREATE TABLE Order_ (
  id INT PRIMARY KEY,
  street_number INT,
  street VARCHAR(25),
  postcode INT,
  town_city VARCHAR(50),
  account_username VARCHAR(50),
  FOREIGN KEY (account_username) REFERENCES Account
);

CREATE TABLE Payment (
  id INT PRIMARY KEY,
  method VARCHAR(20),
  date DATE,
  amount DECIMAL(10, 2),
  order_id INT,
  booking_id INT,
  FOREIGN KEY (order_id) REFERENCES Order_,
  FOREIGN KEY (booking_id) REFERENCES Booking
);

CREATE TABLE Equipment (
  name VARCHAR(50) PRIMARY KEY,
  quantity INT,
  price DECIMAL(10, 2),
  description VARCHAR(1000),
  availability VARCHAR(15),
  check(availability in('availabil', 'not availabil'))
);

CREATE TABLE OrderForEquipment (
  order_id INT,
  equipment_name VARCHAR(50),
  quantity INT,
  PRIMARY KEY (order_id, equipment_name),
  FOREIGN KEY (order_id) REFERENCES Order_,
  FOREIGN KEY (equipment_name) REFERENCES Equipment
);

CREATE TABLE ClassUsesEquipment (
  class_name VARCHAR(50),
  class_date DATE,
  equipment_name VARCHAR(50),
  quantity INT,
  PRIMARY KEY (class_name, class_date)
);

CREATE TABLE instructor (
  instructor_id INT PRIMARY KEY,
  fname VARCHAR(25),
  lname VARCHAR(25),
  phone_number int,
  qualifications VARCHAR(50)
);

CREATE TABLE instructorTeachesClass (
  instructor_id INT,
  class_name VARCHAR(50),
  class_date DATE,
  class_time TIME,
  PRIMARY KEY (instructor_id, class_name, class_date, class_time),
  FOREIGN KEY (instructor_id) REFERENCES instructor,
  FOREIGN KEY (class_name, class_date, class_time) REFERENCES class
  );

  INSERT INTO Customer(customer_id, fname, lname, phone_number, organisation) values(10000, 'John', 'Smith', '5551234567', 'Mincarb inc');
  INSERT INTO Customer(customer_id, fname, lname, phone_number, organisation) values(11220, 'Mary', 'James', '5554545455', 'Book company inc');  INSERT INTO Booking(id, amount_of_students, customer_id) values(87899, 5, 10000);  INSERT INTO Booking(id, amount_of_students, customer_id) values(25636, 5, 11220);  INSERT INTO Course(course_name, duration_minutes) values ('Advanced First Aid', 60);  INSERT INTO Course(course_name, duration_minutes) values ('Wilderness First Aid', 180);  INSERT INTO Class (class_name, class_date, class_time, cost, number_of_students, course_name)  values ('Mincarb Training', '2023-06-27', '12:00:00', 250.50, 5, 'Advanced First Aid');  INSERT INTO Class (class_name, class_date, class_time, cost, number_of_students, course_name)  values ('Book company Wilderness prep', '2023-02-02', '09:00:00', 750.00, 5, 'Wilderness First Aid');DROP TABLE BookingForClass;DROP TABLE BookingForStudent;DROP TABLE Booking;DROP TABLE Customer;