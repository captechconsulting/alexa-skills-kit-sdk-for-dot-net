using Ask.Sdk.Model.Request;
using Ask.Sdk.Model.Request.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask.Sdk.Core.Tests
{
    public abstract class BaseTests : IDisposable
    {
        protected RequestEnvelope Request { get; set; }

        protected Slot Slot { get; set; }

        protected Intent Intent { get; set; }

        protected BaseTests()
        {
            Request = new RequestEnvelope
            {
                Context = new Context
                {
                    System = new SystemState
                    {
                        Application = new Application(),
                        Device = new Device(),
                        User = new User()
                    }
                },
                Request = new LaunchRequest(),
                Session = new Session
                {
                    Application = new Application(),
                    New = true,
                    User = new User
                    {
                        Permissions = new Permissions()
                    }
                },
                Version = "1.0"
            };

            Slot = new Slot();

            Intent = new Intent();
        }

        public virtual void Dispose()
        {
            Request = null;
            Slot = null;
            Intent = null;
        }
    }
}
