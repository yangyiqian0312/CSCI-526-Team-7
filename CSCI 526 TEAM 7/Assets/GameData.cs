using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static float tips;
    public static Customer currCustomer;
    public static int customerIDRange = 5;
    public static int upgradeTipsNeed = 2;
    public static int tipsLevel = 0;


    public class Customer{
        public float customTip;

        // idx0 = spicy
        // idx1 = sweet
        // idx2 = sour
        // idx3 = aromatic
        // idx4 = strength
        // 0 value = whatever; 1 = want this property; -1 = doesn't like this property
        public List<int> requirments = new List<int>();

        // idx0 = Fresh cherry; idx1 = Chili flake; idx2 = gold leaves; idx3 = Pineapples; idx4 = Lemon;
        // idx5 = Orange Syrup; idx6 = Mint
        public int flavoring;

        public string name;

        public int requirementNum;

        public string dialogue;

        public Customer(int currTip, int currSpicy, int currSweet, int currSour, int currAromatic, int currStrength,
            int currFlavoring, string currName, int currRequirementNum, string currDialogue){
                this.customTip = currTip;

                this.requirments.Add(currSpicy);
                this.requirments.Add(currSweet);
                this.requirments.Add(currSour);
                this.requirments.Add(currAromatic);
                this.requirments.Add(currStrength);

                this.flavoring = currFlavoring;

                this.name = currName;

                this.requirementNum = currRequirementNum;
                this.dialogue = currDialogue;
        }
    }

    public static Customer customer1 = new Customer(10, 0, 1, 0, 1, 0, 0, "Sang", 3, 
        "Hi there! Could you make me something SWEET and AROMATIC, and add a CHERRY on top please?");

    public static Customer customer2 = new Customer(10, -1, -1, 1, 0, 0, -1, "Pedro", 3,
         "I'm in the mood for a SOUR drink, but please DON'T make it TOO SWEET or TOO SPICY");

    public static Customer customer3 = new Customer(50, 0, 0, 0, 0, 1, -1, "Wilson", 1, 
        "Just give me something STRONG!");

    public static Customer customer4 = new Customer(40, 0, 0, 0, 1, 0, -1, "Jaq", 1, 
        "Ooh Hello! I would really use a AROMATIC drink now!");

    public static Customer customer5 = new Customer(10, 0, -1, -1, 0, 0, 5, "Kelsey", 3, 
        "A ORANGE SYRUP, but NOT TOO SOUR or TOO SWEET please.");

    public static Customer customer6 = new Customer(5, 0, 0, 0, 0, 0, 6, "Joe", 1, 
        "Hi! A MINT please!");

    public static List<Customer> customers = new List<Customer>() {customer1, customer2, customer3, 
        customer4, customer5, customer6};



}
