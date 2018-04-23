Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.PivotGrid

Namespace PivotGridViewModelBinding
    Public Class ViewModel

        ' The collection of Pivot Grid fields.
        Private privateFields As ObservableCollection(Of Field)
        Public Property Fields() As ObservableCollection(Of Field)
            Get
                Return privateFields
            End Get
            Private Set(ByVal value As ObservableCollection(Of Field))
                privateFields = value
            End Set
        End Property
        ' The collection of Pivot Grid groups.
        Private privateGroups As ObservableCollection(Of FieldGroup)
        Public Property Groups() As ObservableCollection(Of FieldGroup)
            Get
                Return privateGroups
            End Get
            Private Set(ByVal value As ObservableCollection(Of FieldGroup))
                privateGroups = value
            End Set
        End Property
        ' The view model that contains the fields and groups settings.
        Public Sub New()
            Fields = New ObservableCollection(Of Field)() From {
                New Field() With {
                    .FieldName = "Country",
                    .AreaIndex = 0,
                    .FieldArea = FieldArea.RowArea,
                    .Name = "fieldCountry",
                    .GroupName = "groupSalesPerson",
                    .GroupIndex = 0
                },
                New Field() With {
                    .FieldName = "Sales Person",
                    .AreaIndex = 1,
                    .FieldArea = FieldArea.RowArea,
                    .Name = "fieldSalesPerson",
                    .GroupName = "groupSalesPerson",
                    .GroupIndex = 1
                },
                New Field() With {
                    .FieldName = "OrderDate",
                    .AreaIndex = 0,
                    .FieldArea = FieldArea.ColumnArea,
                    .Name = "fieldOrderYear",
                    .Interval = FieldGroupInterval.DateYear,
                    .FieldCaption = "Year",
                    .GroupName = "groupYearMonth",
                    .GroupIndex = 0
                },
                New Field() With {
                    .FieldName = "OrderDate",
                    .AreaIndex = 1,
                    .FieldArea = FieldArea.ColumnArea,
                    .Name = "fieldOrderMonth",
                    .Interval = FieldGroupInterval.DateMonth,
                    .FieldCaption = "Month",
                    .GroupName = "groupYearMonth",
                    .GroupIndex = 1
                },
                New Field() With {
                    .FieldName = "Extended Price",
                    .AreaIndex = 0,
                    .FieldArea = FieldArea.DataArea,
                    .Name = "fieldPrice"
                }
            }
            Groups = New ObservableCollection(Of FieldGroup)() From {
                New FieldGroup() With {.GroupName = "groupYearMonth"},
                New FieldGroup() With {.GroupName = "groupSalesPerson"}
            }
            salesPersonDataAdapter.Fill(salesPersonDataTable)
        End Sub

        Private salesPersonDataTable As New nwindDataSet.SalesPersonDataTable()
        Private salesPersonDataAdapter As New nwindDataSetTableAdapters.SalesPersonTableAdapter()
        Public ReadOnly Property DataSource() As nwindDataSet.SalesPersonDataTable
            Get
                Return salesPersonDataTable
            End Get
        End Property
    End Class
    Public Class Field
        Public Property FieldName() As String
        Public Property Name() As String
        Public Property FieldCaption() As String
        Public Property FieldArea() As FieldArea
        Public Property AreaIndex() As Integer
        Public Property Interval() As FieldGroupInterval
        Public Property GroupName() As String
        Public Property GroupIndex() As Integer
    End Class

    Public Class FieldGroup
        Public Property GroupName() As String
    End Class
End Namespace

