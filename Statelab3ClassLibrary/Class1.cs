using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//this is my class library for this project
namespace Statelab3ClassLibrary
{
    public partial class class1
    {
        //first name the methods and then add in code you want to put in, then go to the dataform
        //and call the method in where it is
        DataClasses1DataContext classdb = new DataClasses1DataContext();
        //have to return and in the list since it is sending to a list you have to initialize the <T> to a string since that is what being used1
        public List<String> ComboMethod()
        {
            var populateCombo = (from state in classdb.States
                                orderby state.STATE_NAME ascending
                                select state.STATE_NAME).ToList();
            return populateCombo;
        }

        //why did i have to put state instead of string?
        public List<State> DFormSearch(string searchTerm)
        {

            var searchData = classdb.States.Where(state =>
                state.STATE_NAME.ToLower().Contains(searchTerm) ||
                state.STATE_POPULATION.ToString().Contains(searchTerm) ||
                state.FLAG_DESCRIPTION.ToLower().Contains(searchTerm) ||
                state.STATE_FLOWER.ToLower().Contains(searchTerm) ||
                state.STATE_BIRD.ToLower().Contains(searchTerm) ||
                state.STATE_COLOR.ToLower().Contains(searchTerm) ||
                state.LARGEST_CITIES.ToLower().Contains(searchTerm) ||
                state.STATE_CAPITAL.ToLower().Contains(searchTerm) ||
                state.MEDIAN_INCOME.ToString().Contains(searchTerm) ||
                state.COMPUTER_JOB_PERCENTAGE.ToString().Contains(searchTerm)

            ).ToList();

            return searchData;
        }

        public List<State> SearchStateMethod(string selectionNo)
        {
            var results = (from state in classdb.States
                           orderby state.STATE_NAME
                           where state.STATE_NAME == selectionNo
                           select state).ToList();
            return results;
        }

        public List<State> StateColorMethod(string selectedColor)
        {
            var populateCombo = (from state in classdb.States
                                orderby state.STATE_COLOR ascending
                                where state.STATE_COLOR == selectedColor
                                select state).ToList();

            return populateCombo;
        }
    }
    public class ErrorClass
    {
        public string GetErrors()
        {
            return ("There was an error Please check your input");
        }
    }

    public class sortButton_Click
    {
        public bool SortDataAsc()
        {
            return true;
        }
        public bool SortDataDesc()
        {
            return false;
        }
    }
   
}
