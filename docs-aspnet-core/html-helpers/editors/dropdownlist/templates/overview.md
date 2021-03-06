---
title: Overview
page_title: DropDownList | Telerik UI for ASP.NET Core HtmlHelpers
description: "Learn the basics when working with the Kendo UI DropDownList HtmlHelper for ASP.NET Core (MVC 6 or ASP.NET Core MVC)."
slug: htmlhelpers_dropdownlist_templates_aspnetcore
position: 4
---

# Templates

The DropDownList uses Kendo UI templates to provide full control over the way an item, a selected value, or a pop-up header is rendered.

 You can either declare the template with an inline string(see Example 1), or reference a script tag by its ID (see Example 2). For more information on the capabilities and syntax of the templates, refer to this [documentation article](https://docs.telerik.com/kendo-ui/framework/templates/overview).


###### Example

```tab-Example1
    <!-- Template -->
    <script id="itemTemplate" type="text/x-kendo-template">
        ContactName: #:data.ContactName#, CustomerID: #:data.CustomerID#
    </script>

    <!-- DropDownList initialization -->
    @(Html.Kendo().DropDownList()
                .Name("customers")
                .DataTextField("ContactName")
                .DataValueField("CustomerID")
                .TemplateId("itemTemplate") //Reference to the template
                .DataSource(source =>
                {
                    source.Read(read =>
                    {
                        read.Action("Template_GetCustomers", "ComboBox");
                    });
                })
    )
```
<!-- Example 2- Inline declaration of the template.

###### Example -->
```tab-Example2
    @(Html.Kendo().DropDownList()
                .Name("customers")
                .DataTextField("ContactName")
                .DataValueField("CustomerID")
                .Template("<span><h3>#: data.ContactName #</h3><p>#: data.CompanyName #</p></span>")
                .DataSource(source =>
                {
                    source.Read(read =>
                    {
                        read.Action("Template_GetCustomers", "ComboBox");
                    });
                })
    )
```



## Item Template

The item template manages the way the list items of a DropDownList are rendered.

The following example demonstrates how to define an item template and how to evaluate it against the dataItem.

###### Example
    <!-- Template -->
    <script id="itemTemplate" type="text/x-kendo-template">
        ContactName: #:data.ContactName#, CustomerID: #:data.CustomerID#
    </script>

    <!-- DropDownList initialization -->
    @(Html.Kendo().DropDownList()
                .Name("customers")
                .DataTextField("ContactName")
                .DataValueField("CustomerID")
                .TemplateId("itemTemplate") //Reference to the template
                .DataSource(source =>
                {
                    source.Read(read =>
                    {
                        read.Action("Template_GetCustomers", "ComboBox");
                    });
                })
    )

## Value Templates

The value template manages the way the selected value of a DropDownList is rendered.

The following example demonstrates how to define a value template.

> **Important**
>
> Value templates must consist of inline HTML elements only.

###### Example

    <!-- Template -->
    <script id="valueTemplate" type="text/x-kendo-template">
        ContactName: #:data.ContactName#
    </script>

    <!-- DropDownList initialization -->
    @(Html.Kendo().DropDownList()
                .Name("customers")
                .DataTextField("ContactName")
                .DataValueField("CustomerID")
                .ValueTemplateId("valueTemplate") //Reference to the template
                .DataSource(source =>
                {
                    source.Read(read =>
                    {
                        read.Action("Template_GetCustomers", "ComboBox");
                    });
                })
    )

## Header Templates

The header template manages the way the pop-up header of a DropDownList is rendered.

The following example demonstrates how to define a header template.

###### Example

    <!-- Template -->
    <script id="headerTemplate" type="text/x-kendo-template">
        <strong>Header</strong>
    </script>

    <!-- DropDownList initialization -->
    @(Html.Kendo().DropDownList()
                .Name("customers")
                .DataTextField("ContactName")
                .DataValueField("CustomerID")
                .HeaderTemplateId("headerTemplate") //Reference to the template
                .DataSource(source =>
                {
                    source.Read(read =>
                    {
                        read.Action("Template_GetCustomers", "ComboBox");
                    });
                })
    )

## Footer Templates

The footer template manages the way the pop-up footer of a DropDownList is rendered. The footer is re-rendered on every change of the Data Source. The context of the template is the widget itself.

The following example demonstrates how to define a footer template.

###### Example

    <!-- Template -->
    <script id="footerTemplate" type="text/x-kendo-template">
        Total <strong>#: instance.dataSource.total() #</strong> items found
    </script>

    <!-- DropDownList initialization -->
    @(Html.Kendo().DropDownList()
                .Name("customers")
                .DataTextField("ContactName")
                .DataValueField("CustomerID")
                .FooterTemplateId("footerTemplate") //Reference to the template
                .DataSource(source =>
                {
                    source.Read(read =>
                    {
                        read.Action("Template_GetCustomers", "ComboBox");
                    });
                })
    )

## No-Data Templates

The DropDownList widget displays `noDataTemplate` in the popup when the data source is empty.

The following example demonstrates how to define a `noDataTemplate` template.

> **Important**
>
> When the `noDataTemplate` option is defined, the widget always opens the popup element.

###### Example

    <!-- Template -->
    <script id="noDataTemplate" type="text/x-kendo-template">
        <strong>No Data!</strong>
    </script>


    <!-- DropDownList initialization -->
    @(Html.Kendo().DropDownList()
                .Name("customers")
                .DataTextField("ContactName")
                .DataValueField("CustomerID")
                .NoDataTemplateId("noDataTemplate") //Reference to the template
                .DataSource(source =>
                {
                    source.Read(read =>
                    {
                        read.Action("Template_GetCustomers", "ComboBox");
                    });
                })
    )



 ## See Also

* [Templates for DropDownList]({% slug htmlhelpers_dropdownlist_templates_aspnetcore %})
* [Bindings for DropDownList]({% slug htmlhelpers_dropdownlist_databinding_aspnetcore %})
* [Grouping in DropDownList]({% slug htmlhelpers_dropdownlist_grouping_aspnetcore %})
* [JavaScript API Reference of the DropDownList](http://docs.telerik.com/kendo-ui/api/javascript/ui/dropdownlist)
* [DropDownList HtmlHelper for ASP.NET MVC](http://docs.telerik.com/aspnet-mvc/helpers/dropdownlist/overview)
* [DropDownList Official Demos](http://demos.telerik.com/aspnet-core/dropdownlist/index)