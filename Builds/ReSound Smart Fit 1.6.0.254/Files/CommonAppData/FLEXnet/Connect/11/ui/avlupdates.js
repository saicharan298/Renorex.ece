        function setsize()
        {
            var oo2=document.getElementById("selectedsize");
            var sizestring="0 " + ar[IDS_KB];
            if( eval(totalselectedsize) < 1024 )
            {
                sizestring = totalselectedsize + " " + ar[IDS_KB];
            }
            else
            {
                sizestring = (Math.round(totalselectedsize*100/1024))/100 +" "+ar[IDS_MB];
            }
            oo2.innerHTML=sizestring;
        }
        
		function LoadString (id)
		{

			var strTable = document.getElementById("StringTable");

			if (strTable == null)
				return "";

			if (strTable.elements[id] == null)
			{
				alert("No String found : "+id);
				return "";
			}
			var i, numargs = arguments.length;
			var retval = new String(strTable.elements[id].value);
			var s, re;
			for (i = 0; i <= numargs; i++)
			{
				s = new String (arguments[i+1]);
				re = new RegExp("\\{"+i+"\\}","g");
				retval = retval.replace(re, s);
			}
			return retval;
		}

		function wopen(id)
		{
			var formobj = document.getElementById("FORM_"+id);
			var obj=formobj.DESCRIPTION;

			if (obj == null)
				return;
			var s=unescape(obj.value);
			var Height = 400;
			var Width = 300;
			var Left = 500;
			var Top = 0;
			var   l=new String(""), srch=new String("");

			if (window.screen) {
				Height = 0.4*screen.height;
				Width = 413;
				Left =  screen.width/2 - Width/2
				Top = screen.height/2 - Height/2;
			}

			var strFeatures;
			strFeatures = 'left=' + Left + ',screenX=' + Left + ',top=' + Top + ',screenY=' + Top + ',width=' + Width + ',height=' + Height+',resizable=no,location=0';

			window.parent.installinstrTarget="InstallationInstruction";
			window.parent.installinstrText=s;
			faqwindow=window.open("InstallInstr.htm", "InstallationInstruction", strFeatures);
			return;
		}

		function scrollup ()
		{
			top.window.scrollTo(0,0);
		}
		function expand(o)
		{
			var oo=document.getElementById("div_"+o);
			var ooo=document.getElementById("image_"+o);
			if (oo != null)
			{
				if (oo.style.display == "block")
				{
					ooo.src="images/down.gif";
					oo.style.display = "none";
				}
				else
				{
					ooo.src="images/up.gif";
					oo.style.display = "block";
				}
			}
		}
		function confirmit(s, basket, b)
		{
			if (b == true)
			{
				var sss = new String(document.getElementById("IDS_AVAILABLEUPDATES_EXCLUSIVE_MSG1").value);
				var i = sss.indexOf("{0}");
				while (i != -1)
				{
					sss = sss.substr(0, i) + unescape(s) + sss.substr(i+3);
					i = sss.indexOf("{0}");
				}
				return (confirm(sss));
			}
			else
			{
				msg=new String(basket).replace("~~~$$$~~~", "");
				var sss = new String(document.getElementById("IDS_AVAILABLEUPDATES_EXCLUSIVE_MSG2").value);
				var i = sss.indexOf("{0}");
				while (i != -1)
				{
					sss = sss.substr(0, i) + unescape(msg) + sss.substr(i+3);
					i = sss.indexOf("{0}");
				}
				i = sss.indexOf("{1}");
				while (i != -1)
				{
					sss = sss.substr(0, i) + unescape(s) + sss.substr(i+3);
					i = sss.indexOf("{1}");
				}
				return (confirm(sss));
			}
		}

		function addme(msgid)
		{
			var formobj = document.getElementById("FORM_"+msgid);
			var basketable = formobj.Basketable.value;
			var downloadtype = formobj.DownloadType.value;
			var mediatype = formobj.MediaType.value;
 			var auth = formobj.AuthID.value;

			var m_msgname="";
			if (m_msgid != "")
			{
 				var s = m_msgid.split("~~~$$$~~~");
 				for (ii = 0; ii < s.length-1; ii++)
				{
 					m_msgname = document.getElementById("FORM_" + s[ii]).MSGNAME.value + "~~~$$$~~~" + m_msgname;
 				}
			}
			var msgname = formobj.MSGNAME.value;

			if (opleasewait.innerHTML==" ")
					return;

			{
				if ( (totalselected && nonbasketinthebasket==true) ||
				     (totalselected && !eval(basketable)) ||
                                                                     (totalselected && eval(downloadtype)==1) ||
				     (totalselected && eval(auth)!=0))
				{
					if (confirmit(msgname, m_msgname, (totalselected && !eval(basketable)) ||
	                                                                     (totalselected && eval(downloadtype)==1) ||
					     (totalselected && eval(auth)!=0)))
					{
						m_msgid="";

                        var nodes=document.getElementsByTagName("input");
                        var inodesize=nodes.length;
						var i;

						for (i = 0;i<inodesize;i++)
						{
							var x=nodes[i];

							if (x == null)
								break;

							var nm=new String (x.name);

							if (nm.indexOf("cb_") == 0)
								x.checked=false;
							totalselected=0;
							totalselectedsize=0;
						}
					}
					else
					{
						document.getElementById("cb_"+msgid).checked = false;
						return;
					}
				}
			}
			document.getElementById("cb_"+msgid).checked = true;
			var mid=new String(m_msgid);
			if (mid.indexOf(msgid+"~~~$$$~~~") != -1)
				return;

			scrollup();
			m_msgid+=msgid+"~~~$$$~~~";

            var oo=document.getElementById("selected");
            totalselected++;
            oo.innerHTML=eval(totalselected);

            totalselectedsize+=eval(formobj.DOWNLOADSIZE.value);
            setsize();
            
			if (document.getElementById("FORM_" + msgid).ElevReq.value != "N")
				totalElevReq++;			
			
			if (totalselected > 0)
			{
				var x=document.getElementById("btnInstall");
				if (mediatype == 4)
					x.disabled=true;
				else
					x.disabled=false;
				x=document.getElementById("btnDownload");
				if ((downloadtype != 0) || (mediatype == 2) || (mediatype == 3) || (mediatype == 10))
				  x.disabled=true;
				else
				  x.disabled=false;
				if (!eval(basketable) || (eval(downloadtype)==1) || eval(auth))
					nonbasketinthebasket=true;
				else
					nonbasketinthebasket=false
				if (eval(WinOSver)>=6)
				{
					if (totalElevReq>0)
						ShowShield(true);
					else
						ShowShield(false);
				}
			}
			else
			{
				nonbasketinthebasket=false;
				var x=document.getElementById("btnInstall");
				x.disabled=true;
				x=document.getElementById("btnDownload");
				x.disabled=true;
				ShowShield(false);
			}
		}

		function removeliteral (str, prop, idx)
		{
			var arr=str.split("~~~\$\$\$~~~");
			var retstr=new String ("");

			if (arr.length <= 0)
				return;

			for (v=0;v < arr.length-1;v++)
			{
				if (v != idx)
					retstr += arr[v] + "~~~\$\$\$~~~";
				if (v > 2)
					break;
			}
			return retstr;
		}

		function removeme (msgid)
		{
			var mid=new String(m_msgid);
			if (mid.indexOf(msgid+"~~~\$\$\$~~~") == -1)
				return;

			scrollup();

			// Get total entries in the row
			// find index of the item to be removed
			// remove indexed item
			msgarray = m_msgid.split("~~~\$\$\$~~~");

			if (msgarray.length <= 0)
				return;

			for (u=0;u < msgarray.length-1;u++)
			{
				if (msgarray [u] == "undefined")
					break;

				if (msgarray [u] == msgid)
					break;
			}

			m_msgid = removeliteral (m_msgid, msgid, u);
            var oo=document.getElementById("selected");
            totalselected--;
            oo.innerHTML=eval(totalselected);

            totalselectedsize-=eval(document.getElementById("FORM_"+msgid).DOWNLOADSIZE.value);
            setsize();

			if (document.getElementById("FORM_" + msgid).ElevReq.value != "N")
				totalElevReq--;			
			
			if (totalselected > 0)
			{
				var x=document.getElementById("btnInstall");
				x.disabled=false;
				x=document.getElementById("btnDownload");
				x.disabled=false;
				if (eval(WinOSver)>=6)
				{
					if (totalElevReq>0)
						ShowShield(true);
					else
						ShowShield(false);
				}
			}
			else
			{
				var x=document.getElementById("btnInstall");
				x.disabled=true;
				x=document.getElementById("btnDownload");
				x.disabled=true;
				ShowShield(false);
			}
		}

		function ShowShield(bShow)
		{
			var x=document.getElementById("imgshield");
			if (bShow == true)
				x.style.display="block";
			else
				x.style.display="none";
		}
		
		var n=true;
		
		function go(act)
		{
			if (act == "RESTORE")
			{
			
				if (exceptionlist.isEmpty() == true)
					alert("Empty list");
				else
				{
					var i;
					for (i=0;i<exceptionlist.GetLength();i++)
					{
						if (exceptionlist.Get(i) != "-1")
							UnDisturb(exceptionlist.Get(i));
					}
					location.reload();
				}
				return;
			}
			// Get total entries in the row
			// find index of the item to be removed
			// remove indexed item
			msgarray = m_msgid.split("~~~\$\$\$~~~");

			window.parent.getupdates.PRODUCTNAME.value="";
			window.parent.getupdates.MSGTYPE.value="";
			window.parent.getupdates.MSGNAME.value="";
			window.parent.getupdates.MSGID.value="";
			window.parent.getupdates.RELEASENAME.value="";
			window.parent.getupdates.UPDATETITLE.value="";
			window.parent.getupdates.DOWNLOADSIZE.value="";
			window.parent.getupdates.DESCRIPTION.value="";
			window.parent.getupdates.DETAILSURL.value="";
			window.parent.getupdates.DOWNLOADURL.value="";
//			window.parent.getupdates.CompanyLogo.value="";
			window.parent.getupdates.MediaType.value="";
			window.parent.getupdates.prid.value="";
			window.parent.getupdates.rlsid.value="";
			window.parent.getupdates.dispver.value="";
			window.parent.getupdates.CommandLine.value="";
			window.parent.getupdates.TargetDir.value="";
//			window.parent.getupdates.LegacyMode.value="";
//			window.parent.getupdates.SDOption.value="";
			window.parent.getupdates.SDURL.value="";
			window.parent.getupdates.AuthID.value="";
			window.parent.getupdates.AuthMsgDisplay.value="";
			window.parent.getupdates.AuthMsgFailed.value="";
			window.parent.getupdates.Details.value="";
			window.parent.getupdates.Basketable.value="";
			window.parent.getupdates.BasketPriority.value="";
//			window.parent.getupdates.WebCommandLine.value=document.location.search;
            window.parent.getupdates.CalloutURL.value="";
            window.parent.getupdates.VersionID.value="";
            window.parent.getupdates.SecurityType.value="";
            window.parent.getupdates.SecuritySignature.value="";
            			window.parent.getupdates.DownloadType.value="";
			window.parent.getupdates.ElevReq.value="";
			window.parent.getupdates.action="getall.htm";
			window.parent.getupdates.installtype.value=act;

			var filler="~~~\$\$\$~~~";

			if (msgarray.length == 2) // only 1 selected
				filler="";

			for (u=0;u != msgarray.length-1;u++)
			{
				var msgid = msgarray [u];

				var formobj = document.getElementById ("FORM_"+msgid);
				if (formobj == null)
					break;
				
				window.parent.getupdates.PRODUCTNAME.value	+=	formobj.PRODUCTNAME.value + filler;
				window.parent.getupdates.MSGTYPE.value		+=	formobj.MSGTYPE.value + filler;
				window.parent.getupdates.MSGNAME.value		+=	formobj.MSGNAME.value + filler;
				window.parent.getupdates.MSGID.value		+=	formobj.MSGID.value + filler;
				window.parent.getupdates.RELEASENAME.value	+=	formobj.DisplayVersion.value + filler;
				window.parent.getupdates.UPDATETITLE.value	+=	formobj.MSGNAME.value + filler;
				window.parent.getupdates.DOWNLOADSIZE.value	+=	formobj.DOWNLOADSIZE.value + filler;
				window.parent.getupdates.DESCRIPTION.value	+=	formobj.DESCRIPTION.value + filler;
				window.parent.getupdates.DETAILSURL.value   +=  formobj.DETAILSURL.value + filler;
				window.parent.getupdates.DOWNLOADURL.value	+=	formobj.DOWNLOADURL.value + filler;
				window.parent.getupdates.MediaType.value		+=	formobj.MediaType.value + filler;
				window.parent.getupdates.prid.value			+=	formobj.prid.value + filler;
				window.parent.getupdates.rlsid.value			+=	formobj.DisplayVersion.value + filler;
				window.parent.getupdates.dispver.value		+=	formobj.DisplayVersion.value + filler;
				window.parent.getupdates.CommandLine.value	+=	formobj.CommandLine.value + filler;
				window.parent.getupdates.TargetDir.value		+=	formobj.TargetDir.value + filler;
				window.parent.getupdates.AuthID.value		+=	formobj.AuthID.value + filler;
				window.parent.getupdates.AuthMsgDisplay.value+=	formobj.AuthMsgDisplay.value + filler;
				window.parent.getupdates.AuthMsgFailed.value	+=	formobj.AuthMsgFailed.value + filler;
				window.parent.getupdates.AuthInfoURL.value	+=	formobj.AuthInfoURL.value + filler;
				window.parent.getupdates.Details.value		+=	formobj.Details.value + filler;
				window.parent.getupdates.Basketable.value	+=	formobj.Basketable.value + filler;
				window.parent.getupdates.BasketPriority.value+=	formobj.BasketPriority.value + filler;
                window.parent.getupdates.CalloutURL.value	+=	formobj.CalloutURL.value + filler;
                window.parent.getupdates.SecurityType.value	+=	formobj.SecurityType.value + filler;
                window.parent.getupdates.SecuritySignature.value += formobj.SecuritySignature.value + filler;
//				if (formobj.CompanyLogo.value !=  "")
//					window.parent.getupdates.CompanyLogo.value += formobj.FilePath.value	+ formobj.CompanyLogo.value + filler;
//				window.parent.getupdates.LegacyMode.value	+=	formobj.LegacyMode.value + filler;
//				window.parent.getupdates.SDOption.value		+=	formobj.SDOption.value + filler;
				window.parent.getupdates.SDURL.value			+=	formobj.SDURL.value + filler;
                window.parent.getupdates.VersionID.value		+=	formobj.VersionID.value + filler;
                			window.parent.getupdates.DownloadType.value 	+= 	formobj.DownloadType.value + filler;
				window.parent.getupdates.ElevReq.value 		+= 	formobj.ElevReq.value + filler;;
			}
						
			if (msgarray.length == 2) // only 1 selected
			{
//				if (act == "DOWNLOAD")
//				{
//					var mediatype = window.parent.getupdates.MediaType.value;
//					var sdurl = window.parent.getupdates.SDURL.value;
//					if (mediatype == 2 || mediatype == 4)
//						if (sdurl != "")
//						{
//							//TBD: When other mediatypes are implemented, we should record mediatype of SDURL
//							window.parent.getupdates.MediaType.value=1;
//							window.parent.getupdates.DOWNLOADURL.value = sdurl;
//						}
//						else
//						{
//							alert("No Download option specified for this update at " + window.parent.getupdates.DOWNLOADURL.value);
//							return;
//						}
//				}
				
		        var x=new String(window.parent.getupdates.AuthID.value);
				if (x!="" && x.length!=0 && x!="undefined" && x!=0)
				{
					window.parent.getupdates.target="";
					window.parent.getupdates.installtype.value=act;
					window.parent.getupdates.action="AuthenticateProduct.htm";
					window.parent.DoAuthentication(formobj.prid.value, formobj.MSGID.value);
					return;
				}
				else
				{ 
					if(navigator.userAgent.indexOf("MSIE") <= -1)
					{
						window.parent.getupdates.target="";
						window.parent.getupdates.DESCRIPTION.value=window.parent.getupdates.DOWNLOADURL.value;
						window.parent.getupdates.action="UpdateComplete.htm" + "&type=DOWNLOAD&Status=UnKnown";
					}
				}
			}
			window.parent.DoGetUpdates();
		}


imgout=new Image(9,9);
imgin=new Image(9,9);

/////////////////BEGIN USER EDITABLE///////////////////////////////
	imgout.src="images/u.gif";
	imgin.src="images/d.gif";
///////////////END USER EDITABLE///////////////////////////////////

//this switches expand collapse icons
function filter(imagename,objectsrc){
	if (document.images){
		document.images[imagename].src=eval(objectsrc+".src");
	}
}

function boxchecked(id) {
    var o = document.getElementById("cb_"+id);
    if (o.checked == true)
        addme(id);
    else
        removeme(id);
    setMsgOld(id);
}

var exceptionlist = new USArray();

function restoreboxchecked(id, msgid) {
    var o = document.getElementById("cb_"+id);
    if (o.checked == true)
    {
		exceptionlist.AddtoList(msgid);
		totalselected++;
		checkselected();
    }
    else
    {
    	exceptionlist.RemoveFromList(msgid);
    	totalselected--;
    	checkselected();
    }
	var x=document.getElementById("btnRestore");
    if (exceptionlist.isEmpty() == false)
		x.disabled=false;
	else
		x.disabled=true;
}
function checkselected()
{
    var oo=document.getElementById("selected");
    oo.innerHTML=eval(totalselected);
}
//show OR hide funtion depends on if element is shown or hidden
function shoh(id, msgID, productID, versionID) {
    var msgShown = false;
	if (document.getElementById) { // DOM3 = IE5, NS6
		if (document.getElementById(id).style.display == "none"){
			document.getElementById(id).style.display = 'block';
			filter(("img"+id),'imgin');
            msgShown = true;
		} else {
			filter(("img"+id),'imgout');
			document.getElementById(id).style.display = 'none';
		}	
	} else { 
		if (document.layers) {	
			if (document.id.display == "none"){
				document.id.display = 'block';
				filter(("img"+id),'imgin');
				msgShown = true;
			} else {
				filter(("img"+id),'imgout');	
				document.id.display = 'none';
			}
		} else {
			if (document.getElementById.id.style.visibility == "none"){
				document.getElementById.id.style.display = 'block';
				msgShown = true
			} else {
				filter(("img"+id),'imgout');
				document.getElementById.id.style.display = 'none';
			}
		}
	}
	if (id.lastIndexOf("A") != (id.length-1)) {
		setMsgOld(id.substr(3));
		if(msgShown) {
            logMsgDisplayed(msgID, productID, versionID);
		}
    }
}

function USArray ()
{
	this.AddtoList=AddtoArray;
	this.RemoveFromList=RemoveFromArray;
	this.m_list=new Array();
	this.PrintList=PrintArray;
	this.isEmpty=isArrayEmpty;
	this.Get=GetArrayElement;
	this.GetLength=GetArrayLength;
}

function GetArrayLength ()
{
	return this.m_list.length;
}

function GetArrayElement(i)
{
	return this.m_list[i];
}

function isArrayEmpty()
{
	var i;
	if (this.m_list.length == 0)
		return true;
	for (i=0;i<this.m_list.length;i++)
		if (this.m_list[i] != "-1")
			return false;
	return true;
}

function PrintArray()
{
	var i;
	for (i=0;i<this.m_list.length;i++)
	{
		alert(this.m_list[i]);
	}
}

function RemoveFromArray(id)
{
	var i;
	for (i=0;i<this.m_list.length;i++)
		if (this.m_list[i]==id)
		{
			this.m_list[i]="-1";
			break;
		}
}

function AddtoArray(id)
{
	var i;
	for (i=0;i < this.m_list.length;i++)
		if (this.m_list[i]=="-1")
		{
			this.m_list[i]=id;;
			return;
		}
	this.m_list[i]=id;
}

function UnDisturb (o)
{
	window.parent.usUpdates.Item(o).AddToExceptionList(-1);
}
function DonotDisturb (o, msgID, productID, versionID)
{
	window.parent.usUpdates.Item(o).AddToExceptionList(0);
	logMsgHidden(msgID, productID, versionID);
	location.reload();
}

function setMsgOld(id)
{
	var f = document.getElementById("FORM_"+id);
	var ar = id.split("_");
	if (typeof(webagent) == "object") {
		if (typeof(webagent.SetMsgNew) != "undefined") {
			webagent.SetMsgNew(f.prid.value, ar[1], 0);
			document.getElementById("UpdateNameCell_" + id).className = "updatesUpdateNameCell";
			document.getElementById("Name_" + id).innerText = f.MSGNAME.value;
		}
	}
}

function logMsgHidden(msgID, productID, versionID)
{
    if(typeof(webagent) == "undefined") {
        return;
    }
    
    if(typeof(webagent.Report) != "undefined") {
        webagent.Report("MSGHIDDEN", msgID, productID, versionID);
    } else {
        var ampchar = "%26";
        var v = "verb=MSGHIDDEN" + unescape(ampchar) + "triplets=" + msgID + "," + productID + "," + versionID + unescape(ampchar) + "comments=Message from Web SIte";
        webagent.ProductCode = productID;
        webagent.Home(v, 0);
    }
}

function logMsgDisplayed(msgID, productID, versionID)
{
    if(typeof(webagent) == "undefined") {
        return;
    }
    
    if(typeof(webagent.Report) != "undefined") {
        webagent.Report("MSGDISPLAYED", msgID, productID, versionID);
    } else {
        var ampchar = "%26";
        var v = "verb=MSGDISPLAYED" + unescape(ampchar) + "triplets=" + msgID + "," + productID + "," + versionID + unescape(ampchar) + "comments=Message from Web Site";
        webagent.ProductCode = productID;
        webagent.Home(v, 0);        
    }
}
