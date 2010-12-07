<Query Kind="Statements">
  <Connection>
    <ID>337b631f-296e-4a3b-aa36-09f23a9a9a38</ID>
    <Server>.\SQLEXPRESS</Server>
    <Database>mc_sz04a</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

Dictionary<string,string> dConn = new Dictionary<string,string>();
Dictionary<int?,string> dFlow = new Dictionary<int?,string>();
var totalMessge=LA_updates.Take (10000);
for(int m=0;m<3;m++)
{
foreach(LINQPad.User.LA_update i in totalMessge)
{  
   if(i.Sccp_slr !=null && i.Sccp_dlr !=null)
   {
     if(!dConn.ContainsKey(i.M3ua_opc+i.M3ua_dpc+i.Sccp_slr) || !dConn.ContainsKey(i.M3ua_opc+i.M3ua_dpc+i.Sccp_dlr))
     {
        dConn.Add(i.M3ua_opc+i.M3ua_dpc+i.Sccp_slr,i.M3ua_opc+i.M3ua_dpc+i.Sccp_slr+i.Sccp_dlr );
        dConn.Add(i.M3ua_opc+i.M3ua_dpc+i.Sccp_dlr,i.M3ua_opc+i.M3ua_dpc+i.Sccp_slr+i.Sccp_dlr );
		dConn.Add(i.M3ua_dpc+i.M3ua_opc+i.Sccp_slr,i.M3ua_opc+i.M3ua_dpc+i.Sccp_slr+i.Sccp_dlr );
		dConn.Add(i.M3ua_dpc+i.M3ua_opc+i.Sccp_dlr,i.M3ua_opc+i.M3ua_dpc+i.Sccp_slr+i.Sccp_dlr );
		dFlow.Add(i.PacketNum,i.M3ua_opc+i.M3ua_dpc+i.Sccp_slr+i.Sccp_dlr);
     }
   }
   if(i.Tmsi !=null && i.Sccp_slr == null && i.Sccp_dlr == null)
	  if( dConn.ContainsKey(i.Tmsi)) 
	    if(!dFlow.ContainsKey(i.PacketNum))
	       dFlow.Add(i.PacketNum,dConn[i.Tmsi]);
   if(i.Sccp_slr != null)
   {
    if(dConn.ContainsKey(i.M3ua_opc+i.M3ua_dpc+i.Sccp_slr))
	   if(!dFlow.ContainsKey(i.PacketNum))
	     {
	       dFlow.Add(i.PacketNum,dConn[i.M3ua_opc+i.M3ua_dpc+i.Sccp_slr]);   
		   if(i.Tmsi !=null)
	          dConn.Add(i.Tmsi,dConn[i.M3ua_opc+i.M3ua_dpc+i.Sccp_slr]);
		 }
	}
   if(i.Sccp_dlr != null)
   {
    if(dConn.ContainsKey(i.M3ua_opc+i.M3ua_dpc+i.Sccp_dlr))
	 if(!dFlow.ContainsKey(i.PacketNum))
        {
	     dFlow.Add(i.PacketNum,dConn[i.M3ua_opc+i.M3ua_dpc+i.Sccp_dlr]);
		 if(i.Tmsi !=null)
	        dConn.Add(i.Tmsi,dConn[i.M3ua_opc+i.M3ua_dpc+i.Sccp_dlr]);
		}
    }
}
}
dFlow.Count().Dump();
var  connLookup = dFlow.ToLookup(e=>e.Value);
var xml=XElement.Load(@"G:\wiresharkplugin\wsFollow\defineflow.xml");

create table ......

foreach (var i in connLookup)
{
    var nLst=i.Select(e=>e.Key);
	var nFlow=totalMessge.Where(e=>nLst.Contains(e.PacketNum));
	var sccp=nFlow.Where(e=>e.Ip_version_MsgType=="SCCP.Release Complete").FirstOrDefault();
	if(sccp!=null)
     foreach(int n in nLst)
       foreach(var a in xml.Elements().Elements())
          if(a.Attribute ("Name").Value==n.Key)
		  {
		     a.Elements("Column").Attributes("Name");
		     a.SetAttributeValue("Data",n.id);
		  }

	
insert sql......
	
}
dFlow.Count().Dump();