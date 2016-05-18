using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sol_Calc_Online
{
    [Serializable]
    public partial class Default : System.Web.UI.Page
    {
        List<TollingPeriod> periodList = new List<TollingPeriod>();

        protected void Page_Load(object sender, EventArgs e)
        {
            // This keeps the user in the same scroll-position on postback/page-reload. Especially on mobile.
            Page.MaintainScrollPositionOnPostBack = true;

            // Serialization to save user-entered values on postback.
            if (ViewState["periodListInViewState"] != null)
            {
                periodList = (List<TollingPeriod>)ViewState["periodListInViewState"];
            }
            
        }
        
        void Page_PreRender(object sender, EventArgs e)
        {
            // Save PageArrayList before the page is rendered.
            ViewState.Add("periodListInViewState", periodList);
        }

        protected void AddPeriodButton_Click(object sender, EventArgs e)
        {
            DateTime startPeriod = Convert.ToDateTime(StartPeriodTextBox.Text);
            DateTime endPeriod = Convert.ToDateTime(EndPeriodTextbox.Text);

            TollingPeriod period = new TollingPeriod(startPeriod, endPeriod);
            period = CheckPeriodOverlap(period);

            periodList.Add(period);
            System.Diagnostics.Debug.WriteLine("list length: " + periodList.Count);

            PeriodListBox.Items.Add(period.ToString());

            ReCalcTotalPeriods();
        }

        private TollingPeriod CheckPeriodOverlap(TollingPeriod newPeriod)
        {
            bool overlap = false;

            foreach (var oldPeriod in periodList)
            {
                DateTime newStart = newPeriod.Start;
                DateTime newEnd = newPeriod.End;

                if (newPeriod.Start <= oldPeriod.End)
                {
                    newStart = oldPeriod.End.AddDays(1);
                }

                TollingPeriod fixedPeriod = new TollingPeriod(newStart, newEnd);

                overlap = newPeriod.Start < oldPeriod.End && oldPeriod.Start < newPeriod.End;
                if (overlap)
                {
                    //MessageBox.Show("Dates overlap.");
                    return fixedPeriod;
                }
            }
            //MessageBox.Show("No overlap.");
            return newPeriod;
        }

        private void ReCalcTotalPeriods()
        {
            double newTotal = 0;
            foreach (var item in periodList)
            {
                newTotal += item.Length;
            }
            TotalPeriodDaysLabel.Text = newTotal.ToString();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var index = PeriodListBox.SelectedIndex;

            if (PeriodListBox.SelectedIndex >= 0)
            {
                System.Diagnostics.Debug.WriteLine("Index: " + index + "list length: " + periodList.Count);
                periodList.RemoveAt(index);
                PeriodListBox.Items.RemoveAt(index);
            }

            ReCalcTotalPeriods();
        }

        protected void DeleteAllButton_Click(object sender, EventArgs e)
        {
            PeriodListBox.Items.Clear();
            periodList.Clear();
            ReCalcTotalPeriods();
        }

        protected bool CheckDataFields()
        {
            bool statusOkay = false;

            if (LimitationLengthTextBox.Text == "")
                LimitationLengthTextBox.Text = "0";
            if (StartTextBox.Text == "")
                StartTextBox.Text = DateTime.Now.ToString("MM/dd/yyyy");
            if (TotalPeriodDaysLabel.Text == "")
                TotalPeriodDaysLabel.Text = "0";

            return statusOkay;
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            CheckDataFields();

            DateTime startDate = Convert.ToDateTime(StartTextBox.Text);
            int yearsOfLimitation = Convert.ToInt32(LimitationLengthTextBox.Text);
            int totalTollingPeriodDays = Convert.ToInt32(TotalPeriodDaysLabel.Text);

            DateTime result = startDate.AddYears(yearsOfLimitation);
            result = result.AddDays(totalTollingPeriodDays);
            ResultTextBox.Text = "\r\n" + result.ToString("MM/dd/yyyy");
        }
    }
}