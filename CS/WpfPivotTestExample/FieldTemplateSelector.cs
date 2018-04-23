using DevExpress.Xpf.PivotGrid;
using System.Windows;
using System.Windows.Controls;

namespace PivotGridViewModelBinding {
    public class FieldTemplateSelector : DataTemplateSelector {
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            Field field = (Field)item;
            if(field.Interval == FieldGroupInterval.DateMonth || field.Interval == FieldGroupInterval.DateYear) {
                return (DataTemplate)((Control)container).FindResource("IntervalFieldTemplate");
            }
            return (DataTemplate)((Control)container).FindResource("DefaultFieldTemplate");
        }
    }
}
