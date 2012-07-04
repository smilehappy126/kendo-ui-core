namespace Kendo.Mvc.UI.Fluent
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Infrastructure;

    /// <summary>
    /// Defines the fluent interface for configuring the <see cref="TreeView"/> component.
    /// </summary>
    public class TreeViewBuilder : ViewComponentBuilderBase<TreeView, TreeViewBuilder>, IHideObjectMembers
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewBuilder"/> class.
        /// </summary>
        /// <param name="component">The component.</param>
        public TreeViewBuilder(TreeView component)
            : base(component)
        {
        }

        /// <summary>
        /// Defines the items in the TreeView
        /// </summary>
        /// <param name="addAction">The add action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .Items(items =>
        ///             {
        ///                 items.Add().Text("First Item");
        ///                 items.Add().Text("Second Item");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder Items(Action<TreeViewItemFactory> addAction)
        {

            TreeViewItemFactory factory = new TreeViewItemFactory(Component, Component.ViewContext);

            addAction(factory);

            return this;
        }

        /// <summary>
        /// Configures the client-side events.
        /// </summary>
        /// <param name="clientEventsAction">The client events action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .Events(events =>
        ///                 .OnDataBinding("onDataBinding")
        ///                 .OnItemDataBound("onItemDataBound")
        ///             )
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder Events(Action<TreeViewEventBuilder> clientEventsAction)
        {
            clientEventsAction(new TreeViewEventBuilder(Component.Events));

            return this;
        }


        /// <summary>
        /// Binds the TreeView to a sitemap
        /// </summary>
        /// <param name="viewDataKey">The view data key.</param>
        /// <param name="siteMapAction">The action to configure the item.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .BindTo("examples", (item, siteMapNode) =>
        ///             {
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder BindTo(string viewDataKey, Action<TreeViewItem, SiteMapNode> siteMapAction)
        {

            Component.BindTo(viewDataKey, siteMapAction);

            return this;
        }


        /// <summary>
        /// Binds the TreeView to a sitemap.
        /// </summary>
        /// <param name="viewDataKey">The view data key.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .BindTo("examples")
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder BindTo(string viewDataKey)
        {

            Component.BindTo(viewDataKey);

            return this;
        }

        /// <summary>
        /// Binds the TreeView to a list of items.
        /// Use if a hierarchy of items is being sent from the controller; to bind the TreeView declaratively, use the Items() method.
        /// </summary>
        /// <param name="items">The list of items</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .BindTo(model)
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder BindTo(IEnumerable<TreeViewItemModel> items)
        {

            Component.BindTo(items, mapping => mapping
                .For<TreeViewItemModel>(binding => binding
                    .ItemDataBound((item, node) => {
                        item.Text = node.Text;
                        item.Enabled = node.Enabled;
                        item.Expanded = node.Expanded;
                        item.LoadOnDemand = node.LoadOnDemand;
                        item.Checked = node.Checked;
                        item.Checkable = node.Checkable;
                        item.Encoded = node.Encoded;
                        item.Value = node.Value;
                        
                        if (!String.IsNullOrEmpty(node.NavigateUrl))
                        {
                            item.Url = node.NavigateUrl;
                        }

                        item.ImageUrl = node.ImageUrl;
                    })
                    .Children(item => item.Items)
                )
            );

            return this;
        }

        /// <summary>
        /// Binds the TreeView to a list of objects. The TreeView will be "flat" which means a TreeView item will be created for 
        /// every item in the data source.
        /// </summary>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <param name="dataSource">The data source.</param>
        /// <param name="itemDataBound">The action executed for every data bound item.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .BindTo(new []{"First", "Second"}, (item, value)
        ///             {
        ///                item.Text = value;
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder BindTo<T>(IEnumerable<T> dataSource, Action<TreeViewItem, T> itemDataBound)
        {

            Component.BindTo(dataSource, itemDataBound);

            return this;
        }

        /// <summary>
        /// Binds the TreeView to a list of objects. The TreeView will create a hierarchy of items using the specified mappings.
        /// </summary>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <param name="dataSource">The data source.</param>
        /// <param name="factoryAction">The action which will configure the mappings</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .BindTo(Model, mapping => mapping
        ///                     .For&lt;Customer&gt;(binding => binding
        ///                         .Children(c => c.Orders) // The "child" items will be bound to the the "Orders" property
        ///                         .ItemDataBound((item, c) => item.Text = c.ContactName) // Map "Customer" properties to TreeViewItem properties
        ///                     )
        ///                     .For&lt;Order&lt;(binding => binding
        ///                         .Children(o => null) // "Orders" do not have child objects so return "null"
        ///                         .ItemDataBound((item, o) => item.Text = o.OrderID.ToString()) // Map "Order" properties to TreeViewItem properties
        ///                     )
        ///             ) 
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder BindTo(IEnumerable dataSource, Action<NavigationBindingFactory<TreeViewItem>> factoryAction)
        {

            Component.BindTo(dataSource, factoryAction);

            return this;
        }

        /// <summary>
        /// Callback for each item.
        /// </summary>
        /// <param name="action">Action, which will be executed for each item.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .ItemAction(item =>
        ///             {
        ///                 item
        ///                     .Text(...)
        ///                     .HtmlAttributes(...);
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder ItemAction(Action<TreeViewItem> action)
        {

            Component.ItemAction = action;

            return this;
        }

        /// <summary>
        /// Select item depending on the current URL.
        /// </summary>
        /// <param name="value">If true the item will be highlighted.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .HighlightPath(true)
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder HighlightPath(bool value)
        {
            Component.HighlightPath = value;

            return this;
        }

        public TreeViewBuilder Animation(bool enable)
        {
            Component.Animation.Enabled = enable;

            return this;
        }

        public TreeViewBuilder Animation(Action<ExpandableAnimationBuilder> animationAction)
        {

            animationAction(new ExpandableAnimationBuilder(Component.Animation));

            return this;
        }

        /// <summary>
        /// Expand all the items.
        /// </summary>
        /// <param name="value">If true all the items will be expanded.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .ExpandAll(true)
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder ExpandAll(bool value)
        {
            Component.ExpandAll = value;

            return this;
        }

        /// <summary>
        /// ShowCheckBox indicates if checkbox displayed before node.
        /// </summary>
        /// <param name="value">If true checkbox will be displayed for every node.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .ShowCheckBox(true)
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder ShowCheckBox(bool value)
        {
            Component.ShowCheckBox = value;

            return this;
        }

        /// <summary>
        /// Enables drag &amp; drop between treeview nodes.
        /// </summary>
        /// <param name="value">If true, drag &amp; drop is enabled.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .Items(items =>
        ///             {
        ///                 items.Add().Text("First Item");
        ///                 items.Add().Text("Second Item");
        ///             })
        ///             .DragAndDrop(true)
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder DragAndDrop(bool value)
        {
            Component.DragAndDrop = value;

            return this;
        }

        /// <summary>
        /// Enable/disable security trimming functionality of the component.
        /// </summary>
        /// <param name="value">If true security trimming is enabled.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .SecurityTrimming(false)
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder SecurityTrimming(bool value)
        {

            Component.SecurityTrimming = value;

            return this;
        }

        /// <summary>
        /// Sets the name of the field that will supply the item text.
        /// </summary>
        /// <param name="field">The field name.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .DataTextField("Name")
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder DataTextField(string field)
        {
            Component.DataTextField = field;

            return this;
        }

        /// <summary>
        /// Sets the name of the field that will supply the item URL.
        /// </summary>
        /// <param name="field">The field name.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .DataUrlField("LinksTo")
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder DataUrlField(string field)
        {
            Component.DataUrlField = field;

            return this;
        }

        /// <summary>
        /// Sets the name of the field that will supply the CSS class for the item sprite image.
        /// </summary>
        /// <param name="field">The field name.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .DataSpriteCssClassField("IconSprite")
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder DataSpriteCssClassField(string field)
        {
            Component.DataSpriteCssClassField = field;

            return this;
        }

        /// <summary>
        /// Sets the name of the field that will supply the URL for the item image.
        /// </summary>
        /// <param name="field">The field name.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        ///             .DataImageUrlField("ImageURL")
        /// %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder DataImageUrlField(string field)
        {
            Component.DataImageUrlField = field;

            return this;
        }

        /// <summary>
        /// Configure the DataSource of the component
        /// </summary>
        /// <param name="configurator">The action that configures the <see cref="ReadOnlyDataSource"/>.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///     .Name("TreeView")
        ///     .DataSource(dataSource => dataSource
        ///         .Read(read => read
        ///             .Action("Employees", "TreeView")
        ///         )
        ///     )
        ///  %&gt;
        /// </code>
        /// </example>
        public TreeViewBuilder DataSource(Action<ReadOnlyDataSourceBuilder> configurator)
        {
            configurator(new ReadOnlyDataSourceBuilder(Component.DataSource, this.Component.ViewContext, this.Component.UrlGenerator));

            return this;
        }
    }
}
