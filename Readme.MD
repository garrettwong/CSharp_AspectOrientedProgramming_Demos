## Setup AOP Interceptors

### Configure NuGet Packages

```Install-Package Unity

Install-Package Unity.Interception```

* Once Unity and Unity.Interception are installed, add to the app.config the following tags:

```<configSections>
<section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration"/>
</configSections>

<unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
<!-- Interception is not part of the default Unity configuration schema. -->
<!-- Before you can configure interception you must add the correct sectionExtension element to your configuration -->
<!-- section in the configuration file.-->
<sectionExtension type="Microsoft.Practices.Unity.InterceptionExtension.Configuration.InterceptionConfigurationExtension, Microsoft.Practices.Unity.Interception.Configuration"/>
<!-- Defines some aliast to easily manipulate the mappings -->
<alias alias="IProxy" type="AOP.IProxy, AOP"/>
<alias alias="Proxy" type="AOP.Proxy, AOP"/>
<alias alias="DiagnosticInterceptor" type="AOP.DiagnosticInterceptor, AOP"/>
<!-- Default Container when creating the tree-chain of resolution-->
<container>
    <!-- Loading the section extension only enables the interception configuration to be given in the configuration file. -->
    <!-- Interception itself will not work unless you also load the interception container extension in your Unity container instance.-->
    <extension type="Interception"/>
    <register type="IProxy" mapTo="Proxy">
    <lifetime type="ContainerControlledLifetimeManager"/>
    <interceptor type="InterfaceInterceptor"/>
    <interceptionBehavior type="DiagnosticInterceptor"/>
    </register>
</container>
</unity>```