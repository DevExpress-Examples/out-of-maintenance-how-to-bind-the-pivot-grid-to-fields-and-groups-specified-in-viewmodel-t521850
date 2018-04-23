Imports DevExpress.Xpf.PivotGrid
Imports System.Windows
Imports System.Windows.Controls

Namespace PivotGridViewModelBinding
    Public Class FieldTemplateSelector
        Inherits DataTemplateSelector

        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            Dim field As Field = DirectCast(item, Field)
            If field.Interval = FieldGroupInterval.DateMonth OrElse field.Interval = FieldGroupInterval.DateYear Then
                Return DirectCast(CType(container, Control).FindResource("IntervalFieldTemplate"), DataTemplate)
            End If
            Return DirectCast(CType(container, Control).FindResource("DefaultFieldTemplate"), DataTemplate)
        End Function
    End Class
End Namespace
