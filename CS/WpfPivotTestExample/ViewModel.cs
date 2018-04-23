using System.Collections.ObjectModel;
using DevExpress.Xpf.PivotGrid;
using PivotGridViewModelBinding.nwindDataSetTableAdapters;

namespace PivotGridViewModelBinding {
    public class ViewModel {

        // The collection of Pivot Grid fields.
        public ObservableCollection<Field> Fields { get; private set; }
        // The collection of Pivot Grid groups.
        public ObservableCollection<FieldGroup> Groups { get; private set; }
        // The view model that contains the fields and groups settings.
        public ViewModel() {
            Fields = new ObservableCollection<Field>() {
                new Field() { FieldName="Country", AreaIndex=0, FieldArea = FieldArea.RowArea, Name="fieldCountry",
                    GroupName="groupSalesPerson", GroupIndex=0},
                new Field() { FieldName="Sales Person", AreaIndex=1, FieldArea = FieldArea.RowArea, Name="fieldSalesPerson",
                    GroupName="groupSalesPerson", GroupIndex=1},
                new Field() { FieldName="OrderDate", AreaIndex=0, FieldArea = FieldArea.ColumnArea, Name="fieldOrderYear",
                    Interval = FieldGroupInterval.DateYear, FieldCaption = "Year", GroupName="groupYearMonth", GroupIndex=0 },
                new Field() { FieldName="OrderDate", AreaIndex=1, FieldArea = FieldArea.ColumnArea, Name="fieldOrderMonth",
                    Interval = FieldGroupInterval.DateMonth, FieldCaption = "Month", GroupName="groupYearMonth", GroupIndex=1 },
                new Field() { FieldName="Extended Price", AreaIndex=0, FieldArea = FieldArea.DataArea, Name="fieldPrice" },
            };
            Groups = new ObservableCollection<FieldGroup>() {
                new FieldGroup() { GroupName = "groupYearMonth" },
                new FieldGroup() { GroupName = "groupSalesPerson" }
            };

            salesPersonDataAdapter.Fill(salesPersonDataTable);            
        }

        nwindDataSet.SalesPersonDataTable salesPersonDataTable = new nwindDataSet.SalesPersonDataTable();
        SalesPersonTableAdapter salesPersonDataAdapter = new SalesPersonTableAdapter();
        public nwindDataSet.SalesPersonDataTable DataSource { get { return salesPersonDataTable; } }
    }

    public class Field {
        public string FieldName { get; set; }
        public string Name { get; set; }
        public string FieldCaption { get; set; }
        public FieldArea FieldArea { get; set; }
        public int AreaIndex { get; set; }
        public FieldGroupInterval Interval { get; set; }
        public string GroupName { get; set; }
        public int GroupIndex { get; set; }
    }
    
    public class FieldGroup {
        public string GroupName { get; set; }
    }
}

