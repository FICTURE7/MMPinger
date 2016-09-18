using System;

namespace MMPinger.Controls
{
    public abstract class ElComponent
    {
        public ElComponent(ElForm form)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));

            _form = form;
        }

        private readonly ElForm _form;
        public ElForm Form
        {
            get
            {
                return _form;
            }
        }

        public virtual void Update()
        {
            // Space
        }
    }
}
