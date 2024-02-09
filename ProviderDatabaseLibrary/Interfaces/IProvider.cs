﻿using ProviderDatabaseLibrary.Models;
using ProviderDatabaseLibrary.Models.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderDatabaseLibrary.Interfaces
{
    public interface IProvider
    {
        //vraca sve klijente
        List<Client> getAllClients();
        //vraca sve planove
        List<Plan> getAllPlans();
        //vraca sve planove za konkretnog klijenta koristeci njegov id
        List<Plan> getActivatedClientPlansByClientID(int clientID);
        //dodavanje klijenta(-1 ako postoji username,1 i vise ako je dodat(broj dodatih redova), 0 ako ima konflikt
        int insertClient(string username,string name,string surname);
        //vraca klijentov id za uneti username,-1 ako ne postoji
        int getClientIdByUsername(string username);
        //brise klijent za poslati id(vraca -1 ako je neuspesno i >0(broj izbrisanih redova) ako je uspesno)
        int removeClientByID(int clientID);
        //update klijenta vraca -1 ako je neuspesno ili >0 ako je uspesno
        int updateClientByID(int clientID, string username, string name, string surname);
        //dodaje plan za klijenta u bazu
        int insertClientPlanByClientID(int clientID, int planID);
        //Uspesno vraca >0,Neuspesno -1,ako postoji vraca 0
        int insertTVPlan(TV_Plan plan);
        //Uspesno vraca >0,Neuspesno -1,ako postoji vraca 0
        int insertInternetPlan(Internet_Plan plan);
        //Uspesno vraca >0,Neuspesno -1,ako postoji vraca 0
        int insertComboPlan(Combo_Plan plan);


    }
}
