#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ExportingDemo.Model;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Syncfusion.Data;
using System.Collections;

namespace ExportingDemo
{
    public class ViewModel
    {
        Northwind northWind;
        public ViewModel()
        {
            ProductInfo = this.GetProductInfo();
            //Employee = new CollectionViewAdv(ProductInfo as IEnumerable);
        }

        private List<Products> _productInfo;

        /// <summary>
        /// Gets or sets the product info.
        /// </summary>
        /// <value>The product info.</value>
        public List<Products> ProductInfo
        {
            get
            {
                return _productInfo;
            }
            set
            {
                _productInfo = value;
               
            }
        }

        public ICollectionView Employee { get; private set; }

        /// <summary>
        /// Gets the product info.
        /// </summary>
        /// <returns></returns>
        public List<Products> GetProductInfo()
        {
            List<Products> productInfo = new List<Products>();
            if (!LayoutControl.IsInDesignMode)
            {
                northWind = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
                var ords = northWind.Products.Take(500);
                foreach (var em in ords)
                {
                    productInfo.Add(em);
                }
            }
            return productInfo;
        }      
    }  
}
