﻿using ComicBookShared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookLibraryManagerWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected bool _disposed = false;

        protected Context Context { get; private set; }

        public BaseController()
        {
            Context = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Context.Dispose();
            }

            _disposed = true;

            base.Dispose(disposing);
        }
    }
}