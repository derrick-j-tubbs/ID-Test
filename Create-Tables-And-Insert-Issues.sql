DROP TABLE IF EXISTS issues
DROP TABLE IF EXISTS customers
CREATE TABLE customers (
    CustomerID int NOT NULL IDENTITY,
    CustomerName varchar(60),
    CustomerAddress varchar(150),
    PurchaseDate date,
     PRIMARY KEY(CustomerID)
)

CREATE TABLE issues (
    IssueID int NOT NULL IDENTITY ,
    IssueRecieved date,
    ContactName varchar(60),
    IssueResponded bit,
    CustomerID int NOT NULL,
    PRIMARY KEY(IssueID),
    FOREIGN KEY(CustomerID) REFERENCES customers(CustomerID),
)


INSERT INTO CUSTOMERS (CustomerName, CustomerAddress, PurchaseDate) VALUES ('Rosario Holifield', '8481 Creek Court, Lindenhurst, NY 11757', '7/6/2001');
INSERT INTO CUSTOMERS (CustomerName, CustomerAddress, PurchaseDate) VALUES ('Matthew Cogdill', '890 Evergreen Ave., Rockledge, FL 32955', '11/29/2008');
INSERT INTO CUSTOMERS (CustomerName, CustomerAddress, PurchaseDate) VALUES ('Helaine Clark', '468 Cherry Hill St., Metairie, LA 70001', '11/29/2008');
INSERT INTO CUSTOMERS (CustomerName, CustomerAddress, PurchaseDate) VALUES ('Roselyn Gallager', '8123 Roehampton St., Adrian, MI 49221', '12/31/2011');
INSERT INTO CUSTOMERS (CustomerName, CustomerAddress, PurchaseDate) VALUES ('Dorine Enger', '48 S. Coffee Street, Onalaska, WI 54650', '12/31/2011');
INSERT INTO CUSTOMERS (CustomerName, CustomerAddress, PurchaseDate) VALUES ('Loyd Winford', '8606 Fulton Ave., Saint Johns, FL 32259', '2/27/2013');
INSERT INTO CUSTOMERS (CustomerName, CustomerAddress, PurchaseDate) VALUES ('Dann Hoosier', '101 Foster Court, Hyde Park, MA 02136', '11/20/2016');
INSERT INTO CUSTOMERS (CustomerName, CustomerAddress, PurchaseDate) VALUES ('Levi Knudsen', '8478 Brook Street, Providence, RI 02904', '11/20/2016');

INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('7/11/2005', 'Shantell Fairbairn', 1, 1);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('5/10/2006', 'Shantell Fairbairn', 1, 1);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('6/15/2007', 'Shantell Fairbairn', 0, 1);

INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('7/11/2017', 'Blain Jackson', 1, 2);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('10/27/2018', 'Blain Jackson', 0, 2);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('5/10/2006', 'Bruno Coletti', 1, 2);

INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('7/11/2005', 'Simon Klock', 1, 3);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('6/15/2007', 'Bruno Coletti', 0, 3);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('7/11/2017', 'Simon Klock', 1, 3);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('10/27/2018', 'Simon Klock', 0, 4);

INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('7/11/2005', 'Simon Klock', 1, 4);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('5/10/2006', 'Simon Klock', 1, 4);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('6/15/2007', 'Sierra Veazey', 0, 5);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('7/11/2017', 'Sierra Veazey', 1, 5);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('10/27/2018', 'Sierra Veazey', 0, 5);

INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('7/11/2005', 'Justin Pepe', 1,6);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('5/10/2006', 'Malcome Chasse', 1,6);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('6/15/2007', 'Justin Pepe', 0, 6);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('7/11/2017', 'Justine Pepe', 1, 7);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('10/27/2018', 'Malcom Chasse', 0, 7);

INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('7/11/2005', 'Enid Wilkerson', 1, 7);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('5/10/2006', 'Enid Wilkerson', 1, 8);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('6/15/2007', 'Enid Wilkerson', 0, 8);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('7/11/2017', 'Delilia Schlottman', 1, 8);
INSERT INTO issues (IssueRecieved, ContactName, IssueResponded, CustomerID) VALUES ('10/27/2018', 'Deonna Frisbee', 0, 8);