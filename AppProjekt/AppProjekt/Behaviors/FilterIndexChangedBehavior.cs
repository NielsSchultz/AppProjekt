using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppProjekt.Behaviors
{
    class FilterIndexChangedBehavior : Behavior<Picker>
    {
        protected override void OnAttachedTo(Picker bindable)
        {
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Picker bindable)
        {
            base.OnDetachingFrom(bindable);
        }
        void Bindable_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
