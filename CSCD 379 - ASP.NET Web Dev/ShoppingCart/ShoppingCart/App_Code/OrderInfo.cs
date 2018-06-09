using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderInfo
/// </summary>
public class OrderInfo {
    private string fname, lname, street, city, state, email;
    private int zip;
    public OrderInfo(string fname, string lname, string street, string city, string state, int zip, string email) {
        this.fname = fname;
        this.lname = lname;
        this.street = street;
        this.city = city;
        this.state = state;
        this.zip = zip;
        this.email = email;
    }

    public OrderInfo() {
        this.fname = null;
        this.lname = null;
        this.street = null;
        this.city = null;
        this.state = null;
        this.zip = 0;
        this.email = null;
    }

    public string Fname {
        get {
            return this.fname;
        } set {
            this.fname = value;
        }
    }

    public string Lname {
        get {
            return this.lname;
        } set {
            this.lname = value;
        }
    }

    public string Street {
        get {
            return this.street;
        } set {
            this.street = value;
        }
    }

    public string City {
        get {
            return this.city;
        } set {
            this.city = value;
        }
    }

    public string State {
        get {
            return this.state;
        } set {
            this.state = value;
        }
    }

    public int Zip {
        get {
            return this.zip;
        } set {
            this.zip = value;
        }
    }

    public string Email {
        get {
            return this.email;
        } set {
            this.email = value;
        }
    }
}