import os
import platform
import mysql.connector
import pandas as pd
import datetime

global z, s

mydb = mysql.connector.connect(user='root', password='12345', host='localhost', database='hotel')
mycursor = mydb.cursor()

def registercust():
    l = []
    name = input("enter name:")
    l.append(name)
    addr = input("enter address")
    l.append(addr)
    indate = input("enter check indate:")
    l.append(indate)
    outdate = input("enter check outdate:")
    l.append(outdate)
    cust = (l)
    sql = "insert into custdata(name,addr,indate,outdate)values(%s,%s,%s,%s)"
    mycursor.execute(sql, cust)
    mydb.commit()

def roomtypeview():
    print("do you want to see the types of rooms available: if yes enter 1")
    ch = int(input("enter your choice:"))
    if ch == 1:
        sql = "select * from roomtype"
        mycursor.execute(sql)
        rows = mycursor.fetchall()
        for x in rows:
            print(x)

def roomrent():
    print("we have the following rooms for you")
    print("1:type Ars1000 pn\-")
    print("2:type B-rs2000 pn\-")
    print("3:type C-rs3000 PN\-")
    print("4:type D-rs4000 PN\-")
    x = int(input("Enter Your Choice Please:"))
    n = int(input("how many nights do you want to stay:"))
    if x == 1:
        print("you have opted room type A")
        s = 1000 * n
    elif x == 2:
        print("you have opted room type B")
        s = 2000 * n
    elif x == 3:
        print("you have opted room type C")
        s = 3000 * n
    elif x == 4:
        print("you have opted room type D")
        s = 4000 * n
    else:
        print("please choose a room")
        print("your room rent is =", s, "\n")

def restaurentmenuview():
    print("we will be providing you the menu available: Enter 1 if yes:")
    ch = int(input("enter your choice:"))
    if ch == 1:
        a = "select * from restaurent:"
        mycursor.execute(a)
        rows = mycursor.fetchall()
        for x in rows:
            print(x)

def orderitem():
    global s
    print("we will be providing you the menu available: Enter 1 if yes:")
    ch = int(input("enter your choice:"))
    if ch == 1:
        b = "select * from restaurent"
        mycursor.execute(b)
        rows = mycursor.fetchall()
        for x in rows:
            print(x)
        print("do you want to purchase from above list:enter your choice:")
        d = int(input("enter your choice:"))
        if d == 1:
            print("you have ordered tea")
            a = int(input("enter quantity"))
            s = 10 * a
            print("your amount for tea is :", s, "\n")
        elif d == 2:
            print("you have ordered coffee")
            a = int(input("enter quantity"))
            s = 10 * a
            print("your amount for coffee is :", s, "\n")
        elif d == 3:
            print("you have ordered cold drink")
            a = int(input("enter quantity"))
            s = 20 * a
            print("your amount for colddrink is :", s, "\n")
        elif d == 4:
            print("you have ordered samosa")
            a = int(input("enter quantity"))
            s = 10 * a
            print("your amount for samosa is :", s, "\n")
        elif d == 5:
            print("you have ordered sandwich")
            a = int(input("enter quantity"))
            s = 50 * a
            print("your amount for sandwich is :", s, "\n")
        elif d == 6:
            print("you have ordered dhokla:")
            a = int(input("enter quantity"))
            s = 30 * a
            print("your amount for dhokla is :", s, "\n")
        elif d == 7:
            print("you have ordered kachori")
            a = int(input("enter quantity"))
            s = 10 * a
            print("your amount for kachori is :", s, "\n")
        elif d == 8:
            print("you have ordered milk")
            a = int(input("enter quantity"))
            s = 20 * a
            print("your amount for milk is :", s, "\n")
        elif d == 9:
            print("you have ordered noodles")
            a = int(input("enter quantity"))
            s = 50 * a
            print("your amount for noodles is :", s, "\n")
        elif d == 10:
            print("you have ordered pasta")
            a = int(input("enter quantity"))
            s = 50 * a
            print("your amount for pastais :", s, "\n")
        else:
            print("please enter your choice from the menu")

def laundarybill():
    global z
    print("Do yoy want to see rate for laundary: Enter 1 for yes :")
    ch = int(input("enter your choice:"))
    if ch == 1:
        sql = "select * from laundary"
        mycursor.execute(sql)
        rows = mycursor.fetchall()
        for x in rows:
            print(x)
        y = int(input("Enter Your number of clothes->"))
        z = y * 10
        print("your laundarybill:", z, "\n")
        return z

global z
z = 0
global s

def viewbill():
    a = input("enter customer name:")
    print("customer name:", a, "\n")
    print("laundarey bill:")
    print(z)
    print("restaurent bill:")
    print(s)

def Menuset():
    print("enter 1: To enter customer data")
    print("enter 2: To view roomtype")
    print("enter 3: for calculating room bill")
    print("enter 4: for viewing restaurent menu")
    print("enter 5: for restaurent bill")
    print("enter 6 :for laundary bill")
    print("enter 7: for complete bill")
    print("enter 8: for exit:")

try:
    userinput = int(input("pleaseselect an above option:"))
except ValueError:
    exit("\n hi thats not a number")
    userinput = int(input("enter your choice"))
    if userinput == 1:
        registercust()
    elif userinput == 2:
        roomtypeview()
    elif userinput == 3:
        roomrent()
    elif userinput == 4:
        restaurentmenuview()
    elif userinput == 5:
        orderitem()
    elif userinput == 6:
        laundarybill()
    elif userinput == 7:
        viewbill()
    elif userinput == 8:
        quit()
    else:
        print("enter correct choice")

Menuset()

def runagain():
    runagn = input("\n want to run again y/n:")
    while runagn.lower() == 'y':
        if platform.system() == "windows":
            print(os.system("cls"))
        else:
            print(os.system('clear'))

Menuset()
runagn = input("\n want to run again y/n:")
runagain()
