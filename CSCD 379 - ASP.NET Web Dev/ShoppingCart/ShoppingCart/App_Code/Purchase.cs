using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Purchase
/// </summary>
public class Purchase {

    private string id;
    private string name;
    private double cost;
    private int qty;
    private double weight;

    public Purchase(string id, string name, double cost, int qty, double weight) {
        this.id = id;
        this.name = name;
        this.cost = cost;
        this.qty = qty;
        this.weight = weight;
    }

    public Purchase(string id, double cost) {
        this.id = id;
        this.cost = cost;
    }
    public Purchase(string id, double cost, int qty) {
        this.id = id;
        this.cost = cost;
        this.qty = qty;
    }

    public string ID {
        get {
            return this.id;
        } set {
            this.id = value;
        }
    }

    public string Name {
        get {
            return this.name;
        } set {
            this.name = value;
        }
    }

    public double Cost {
        get {
            return this.cost;
        } set {
            this.cost = value;
        }
    }

    public int Qty {
        get {
            return this.qty;
        } set {
            this.qty = value;
        }
    }

    public double Weight {
        get {
            return this.weight;
        } set {
            this.weight = value;
        }
    }

}