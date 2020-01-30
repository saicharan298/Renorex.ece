/*
 * Created by Ranorex
 * User: i-ray
 * Date: 30-07-2019
 * Time: 01:37
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using WinForms = System.Windows.Forms;
using XLS = Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
//using WinForms = System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace FeatureFlag_Validation
{
	/// <summary>
	/// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
	/// </summary>
	[UserCodeCollection]
	public class UserCodeCollection1
	{
		
		public static	List<string> XMl_FlagKey=new List<string>();
		public static	List<string> XMl_FlagKey_US=new List<string>();
		public static List<string> XMl_FlagValues=new List<string>();
		public static List<string> XMl_FlagValues_US=new List<string>();
		public static	List<string> Excel_FlagKey=new List<string>();
		public static List<string>  Excel_BrandValues=new List<string>();
		
		
		public static	List<string> Excel_FlagKey2=new List<string>();
		public static List<string>  Excel_BrandValues2=new List<string>();
		
		public static	List<string> XMl_FlagKey2=new List<string>();
		public static	List<string> XMl_FlagKey_US2=new List<string>();
		public static List<string> XMl_FlagValues2=new List<string>();
		public static List<string> XMl_FlagValues_US2=new List<string>();
		// You can use the "Insert New User Code Method" functionality from the context menu,
		// to add a new method with the attribute [UserCodeMethod].
		
		[UserCodeMethod]
		public static void Install_FSW(string Brandname)
		{
			//	Brandname=Brandname.Replace(" ",string.Empty);
			string Brandname2=Brandname.Replace(" ",string.Empty);
			if(Brandname2.Contains("SmartFit"))
			{
				//	Host.Local.RunApplication("C:\\Builds\\"+Brandname+"\\Setup.exe", "", "", false);
				Host.Local.RunApplication("D:\\TFS\\FSW\\TestSuites\\FeatureFlag_Validation\\Builds\\"+Brandname+"\\Setup.exe", "", "", false);
				Delay.Milliseconds(0);
			}
			if(Brandname2.Contains("SolusMax")){
				//	Host.Local.RunApplication("C:\\Builds\\"+Brandname+"\\Setup.exe", "", "", false);
				Host.Local.RunApplication("D:\\TFS\\FSW\\TestSuites\\FeatureFlag_Validation\\Builds\\"+Brandname+"\\Setup.exe", "", "", false);
				Delay.Milliseconds(0);
			}
		}
		
		[UserCodeMethod]
		public static void ExtraNext_Button()
		{
			Delay.Seconds(4);
			try
			{
				Ranorex.Button btnNext="/form[@title~'Smart Fit' or @title~'Solus Max']/button[@text='&Next >']";
				if(btnNext.Visible==true)
				{
					Mouse.Click(btnNext);
				}
			}
			catch
			{
				
			}
		}
		
		
		/// <summary>
		/// This is a placeholder text. Please describe the purpose of the
		/// user code method here. The method is published to the user code library
		/// within a user code collection.
		/// </summary>
		[UserCodeMethod]
		public static void XMl_FlagKey_Method2(string MarketnameKey,string BildnameKey)
		{

			BildnameKey=BildnameKey.Replace(" ",string.Empty);
//			if(MarketnameKey=="United States")
//			{
//				if(BildnameKey.Contains("SmartFit"))
//				{
//					XmlDocument doc = new XmlDocument();
//					doc.Load(@"C:\Program Files (x86)\ReSound\SmartFit\Data\Market\market.fflag");
//					XmlNodeList nodelist = doc.GetElementsByTagName("FeatureFlag");
//					for(int i=0;i<=Excel_FlagKey2.Count-1;i++)
//					{
//						for(int j=0;j<=nodelist.Count-5;j++)
//						{
//							string name=nodelist[j].Attributes[0].InnerText;
//							if(Excel_FlagKey2[i]==name)
//							{
//								if(Excel_FlagKey2[i]=="teleaudiology-master" || Excel_FlagKey2[i]=="teleaudiology-video-fsw" ||Excel_FlagKey2[i]=="teleaudiology-fitting-fsw" || Excel_FlagKey2[i]=="teleaudiology-tsgrestricted-fsw")
//								{
//									
//								}
//								else
//								{
//									string Value=nodelist[j].Attributes[1].InnerText;
//									string excelvalue=Excel_BrandValues2[i];
//									Value=Value.ToLower();
//									excelvalue=excelvalue.ToLower();
//									if(Value.Contains("true") && excelvalue.Contains("on"))
//									{
//										Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  True "+ "= "+ " ON ");
//									}
//									else if(Value.Contains("false") && excelvalue.Contains("off"))
//									{
//										Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  False "+ "= "+ " OFF ");
//									}
//									else
//									{
//										Report.Failure("Fail :"+Excel_FlagKey2[i] +" : FeatureFlag Value of Flag file is :"+Value +" -and Excel File is :"+Excel_BrandValues2[i]);
//									}
//								}
//							}
//						}
//						
//						int US_count=nodelist.Count-5;
//						for(int k=US_count;k<=nodelist.Count-1;k++)
//						{
//							string name=nodelist[k].Attributes[0].InnerText;
//							if(Excel_FlagKey2[i]==name)
//							{
//								if(Excel_FlagKey2[i]=="teleaudiology-master" || Excel_FlagKey2[i]=="teleaudiology-video-fsw" ||Excel_FlagKey2[i]=="teleaudiology-fitting-fsw" || Excel_FlagKey2[i]=="teleaudiology-tsgrestricted-fsw")
//								{
//									string Value=nodelist[k].Attributes[1].InnerText;
//									string excelvalue=Excel_BrandValues2[i];
//									Value=Value.ToLower();
//									excelvalue=excelvalue.ToLower();
//									if(Value.Contains("true") && excelvalue.Contains("on"))
//									{
//										Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  True "+ "= "+ " ON ");
//									}
//									else if(Value.Contains("false") && excelvalue.Contains("off"))
//									{
//										Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  False "+ "= "+ " OFF ");
//									}
//									else
//									{
//										Report.Failure("Fail :"+Excel_FlagKey2[i] +" : FeatureFlag Value of Flag file is :"+Value +" -and Excel File is :"+Excel_BrandValues2[i]);
//									}
//								}
//							}
//							
//						}
//						
//					}
//					
//					
//				}
//				
//				else if(BildnameKey.Contains("SolusMax"))
//				{
//					XmlDocument doc = new XmlDocument();
//					doc.Load(@"C:\Program Files (x86)\Beltone\SolusMax\Data\Market\market.fflag");
//					XmlNodeList nodelist = doc.GetElementsByTagName("FeatureFlag");
//					for(int i=0;i<=Excel_FlagKey2.Count-1;i++)
//					{
//						for(int j=0;j<=nodelist.Count-5;j++)
//						{
//							string name=nodelist[j].Attributes[0].InnerText;
//							if(Excel_FlagKey2[i]==name)
//							{
//								if(Excel_FlagKey2[i]=="teleaudiology-master" || Excel_FlagKey2[i]=="teleaudiology-video-fsw" ||Excel_FlagKey2[i]=="teleaudiology-fitting-fsw" || Excel_FlagKey2[i]=="teleaudiology-tsgrestricted-fsw")
//								{
//									
//								}
//								else
//								{
//									string Value=nodelist[j].Attributes[1].InnerText;
//									string excelvalue=Excel_BrandValues2[i];
//									Value=Value.ToLower();
//									excelvalue=excelvalue.ToLower();
//									if(Value.Contains("true") && excelvalue.Contains("on"))
//									{
//										Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  True "+ "= "+ " ON ");
//									}
//									else if(Value.Contains("false") && excelvalue.Contains("off"))
//									{
//										Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  False "+ "= "+ " OFF ");
//									}
//									else
//									{
//										Report.Failure("Fail :"+Excel_FlagKey2[i] +" : FeatureFlag Value of Flag file is :"+Value +" -and Excel File is :"+Excel_BrandValues2[i]);
//									}
//								}
//							}
//						}
//						
//						int US_count=nodelist.Count-5;
//						for(int k=US_count;k<=nodelist.Count-1;k++)
//						{
//							string name=nodelist[k].Attributes[0].InnerText;
//							if(Excel_FlagKey2[i]==name)
//							{
//								if(Excel_FlagKey2[i]=="teleaudiology-master" || Excel_FlagKey2[i]=="teleaudiology-video-fsw" ||Excel_FlagKey2[i]=="teleaudiology-fitting-fsw" || Excel_FlagKey2[i]=="teleaudiology-tsgrestricted-fsw")
//								{
//									string Value=nodelist[k].Attributes[1].InnerText;
//									string excelvalue=Excel_BrandValues2[i];
//									Value=Value.ToLower();
//									excelvalue=excelvalue.ToLower();
//									if(Value.Contains("true") && excelvalue.Contains("on"))
//									{
//										Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  True "+ "= "+ " ON ");
//									}
//									else if(Value.Contains("false") && excelvalue.Contains("off"))
//									{
//										Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  False "+ "= "+ " OFF ");
//									}
//									else
//									{
//										Report.Failure("Fail :"+Excel_FlagKey2[i] +" : FeatureFlag Value of Flag file is :"+Value +" -and Excel File is :"+Excel_BrandValues2[i]);
//									}
//								}
//							}
//							
//						}
//						
//					}
//					
//					
//					
//				}
//			}
//			else
//			{
				if(BildnameKey.Contains("SmartFit"))
				{
					XmlDocument doc = new XmlDocument();
					doc.Load(@"C:\Program Files (x86)\ReSound\SmartFit\Data\Market\market.fflag");
					XmlNodeList nodelist = doc.GetElementsByTagName("FeatureFlag");
					for(int i=0;i<=Excel_FlagKey2.Count-1;i++)
					{
						for(int j=0;j<=nodelist.Count-1;j++)
						{
							string name=nodelist[j].Attributes[0].InnerText;
							if(Excel_FlagKey2[i]==name)
							{
								string Value=nodelist[j].Attributes[1].InnerText;
								string excelvalue=Excel_BrandValues2[i];
								Value=Value.ToLower();
								excelvalue=excelvalue.ToLower();
								if(Value.Contains("true") && excelvalue.Contains("on"))
								{
									Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  True "+ "= "+ " ON ");
								}
								else if(Value.Contains("false") && excelvalue.Contains("off"))
								{
									Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  False "+ "= "+ " OFF ");
								}
								else
								{
									Report.Failure("Fail :"+Excel_FlagKey2[i] +" : FeatureFlag Value of Flag file is :"+Value +" -and Excel File is :"+Excel_BrandValues2[i]);
								}
								
							}
							
						}
					}
				}
				else if(BildnameKey.Contains("SolusMax"))
				{
					XmlDocument doc = new XmlDocument();
					doc.Load(@"C:\Program Files (x86)\Beltone\SolusMax\Data\Market\market.fflag");
					XmlNodeList nodelist = doc.GetElementsByTagName("FeatureFlag");
					for(int i=0;i<=Excel_FlagKey2.Count-1;i++)
					{
						for(int j=0;j<=nodelist.Count-1;j++)
						{
							string name=nodelist[j].Attributes[0].InnerText;
							if(Excel_FlagKey2[i]==name)
							{
								string Value=nodelist[j].Attributes[1].InnerText;
								string excelvalue=Excel_BrandValues2[i];
								Value=Value.ToLower();
								excelvalue=excelvalue.ToLower();
								if(Value.Contains("true") && excelvalue.Contains("on"))
								{
									Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  True "+ "= "+ " ON ");
								}
								else if(Value.Contains("false") && excelvalue.Contains("off"))
								{
									Report.Success("Pass :"+Excel_FlagKey2[i]+ "-  False "+ "= "+ " OFF ");
								}
								else
								{
									Report.Failure("Fail :"+Excel_FlagKey2[i] +" : FeatureFlag Value of Flag file is :"+Value +" -and Excel File is :"+Excel_BrandValues2[i]);
								}
								
							}
							
						}
					}
				}
				
		//	}
			
			
		}
		[UserCodeMethod]
		public static void XMl_FlagKey_Method(string BildnameKey,string MarketnameKey)
		{
			XMl_FlagKey.Clear();
			XMl_FlagKey_US.Clear();
//			if(MarketnameKey=="United States")
//			{
//				if(BildnameKey.Contains("SmartFit"))
//				{
//					//	XMl_FlagKey.Clear();
//					XmlDocument doc = new XmlDocument();
//					doc.Load(@"C:\Program Files (x86)\ReSound\SmartFit\Data\Market\market.fflag");
//					XmlNodeList nodelist = doc.GetElementsByTagName("FeatureFlag");
//					
//					for(int i=0;i<=nodelist.Count-5;i++)
//					{
//						string name=nodelist[i].Attributes[0].InnerText;
//						XMl_FlagKey.Add(name);
//						
//					}
//					for(int j=28;j<=nodelist.Count-1;j++)
//					{
//						string name2=nodelist[j].Attributes[0].InnerText;
//						XMl_FlagKey_US.Add(name2);
//					}
//				}
//				else if(BildnameKey.Contains("SolusMax"))
//				{
//					//	XMl_FlagKey.Clear();
//					XmlDocument doc = new XmlDocument();
//					doc.Load(@"C:\Program Files (x86)\Beltone\SolusMax\Data\Market\market.fflag");
//					XmlNodeList nodelist = doc.GetElementsByTagName("FeatureFlag");
//					
//					for(int i=0;i<=nodelist.Count-5;i++)
//					{
//						string name=nodelist[i].Attributes[0].InnerText;
//						XMl_FlagKey.Add(name);
//						
//					}
//					for(int j=28;j<=nodelist.Count-1;j++)
//					{
//						string name2=nodelist[j].Attributes[0].InnerText;
//						XMl_FlagKey_US.Add(name2);
//					}
//				}
//			}
//			else
//			{
				if(BildnameKey.Contains("SmartFit"))
				{
					XMl_FlagKey.Clear();
					XmlDocument doc = new XmlDocument();
					doc.Load(@"C:\Program Files (x86)\ReSound\SmartFit\Data\Market\market.fflag");
					XmlNodeList nodelist = doc.GetElementsByTagName("FeatureFlag");
					
					for(int i=0;i<=nodelist.Count-1;i++)
					{
						string name=nodelist[i].Attributes[0].InnerText;
						XMl_FlagKey.Add(name);
						
					}
				}
				else if(BildnameKey.Contains("SolusMax"))
				{
					XMl_FlagKey.Clear();
					XmlDocument doc = new XmlDocument();
					doc.Load(@"C:\Program Files (x86)\Beltone\SolusMax\Data\Market\market.fflag");
					XmlNodeList nodelist = doc.GetElementsByTagName("FeatureFlag");
					
					for(int i=0;i<=nodelist.Count-1;i++)
					{
						string name=nodelist[i].Attributes[0].InnerText;
						XMl_FlagKey.Add(name);
						
					}
				}
		//	}
		}
		
		[UserCodeMethod]
		public static void XML_FeatureFlag_Values_Method(string BildnameValues)
		{
			XMl_FlagValues.Clear();
			XMl_FlagValues_US.Clear();
			if(BildnameValues.Contains("SmartFit"))
			{
				//	XMl_FlagValues.Clear();
				XmlDocument doc = new XmlDocument();
				doc.Load(@"C:\Program Files (x86)\ReSound\SmartFit\Data\Market\market.fflag");
				XmlNodeList nodelist = doc.GetElementsByTagName("FeatureFlag");
				
				for(int i=0;i<=nodelist.Count-5;i++)
				{
					string name=nodelist[i].Attributes[1].InnerText;
					XMl_FlagValues.Add(name);
					
				}
				for(int j=28;j<=nodelist.Count-1;j++)
				{
					string name2=nodelist[j].Attributes[1].InnerText;
					XMl_FlagValues_US.Add(name2);
				}
			}
			//	else if(BildnameValues=="SolusMax")
			else if(BildnameValues.Contains("SolusMax"))
			{
				//	XMl_FlagValues.Clear();
				XmlDocument doc = new XmlDocument();
				doc.Load(@"C:\Program Files (x86)\Beltone\SolusMax\Data\Market\market.fflag");
				XmlNodeList nodelist = doc.GetElementsByTagName("FeatureFlag");
				
				for(int i=0;i<=nodelist.Count-5;i++)
				{
					string name=nodelist[i].Attributes[1].InnerText;
					XMl_FlagValues.Add(name);
					
				}
				for(int j=28;j<=nodelist.Count-1;j++)
				{
					string name2=nodelist[j].Attributes[1].InnerText;
					XMl_FlagValues_US.Add(name2);
				}
			}
			
		}
		
		
		/// <summary>
		/// This is a placeholder text. Please describe the purpose of the
		/// user code method here. The method is published to the user code library
		/// within a user code collection.
		/// </summary>
		[UserCodeMethod]
		public static void Excel_FlagKeyMethod2(string Marketname,string Buildname_ExcelValues)
		{
			Excel_FlagKey2.Clear();
			Excel_BrandValues2.Clear();
			Buildname_ExcelValues=Buildname_ExcelValues.Replace(" ",string.Empty);
			if(Buildname_ExcelValues.Contains("SmartFit"))
			{
//				if(Marketname=="United States")
//				{
//					string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Bohrium_4_Feature Flags.xlsx";
//					Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
//					XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
//
//					Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[2];
//					Excel.Worksheet worksheet2 = (Excel.Worksheet)workBook.Worksheets[3];
//					for(int i=3;i<=10;i++)
//					{
//						object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 1]).Value;
//						if(cellValue !=null)
//						{
//							string j=cellValue.ToString();
//							j=j.Trim();
//							if(j != "teleaudiology-master")
//							{
//								Excel_FlagKey2.Add(j);
//								object KeyValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 3]).Value;
//								string _key=KeyValue.ToString();
//								_key=_key.Trim();
//								Excel_BrandValues2.Add(_key);
//							}
//						}
//					}
//					for(int j=2;j<=5;j++)
//					{
//						object KeyValue2 = ((Microsoft.Office.Interop.Excel.Range)worksheet2.Cells[j, 3]).Value;
//						object cellValue2 = ((Microsoft.Office.Interop.Excel.Range)worksheet2.Cells[j, 1]).Value;
//						if(cellValue2 !=null)
//						{
//							string k=cellValue2.ToString();
//							k=k.Trim();
//							Excel_FlagKey2.Add(k);
//							string _key2=KeyValue2.ToString();
//							_key2=_key2.Trim();
//							Excel_BrandValues2.Add(_key2);
//						}
//					}
//					workBook.Close(0);
//					application.Quit();
//
//				}
				
//				else
//				{
				string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Bohrium_4_Feature Flags.xlsx";
				Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
				XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
				Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[2];
				for(int i=3;i<=21;i++)
				{
					object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 1]).Value;
					object KeyValue2 = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 3]).Value;
					if(cellValue !=null)
					{

						string j=cellValue.ToString();
						j=j.Trim();
						string _key2=KeyValue2.ToString();
						_key2=_key2.Trim();
						
//							if(j=="teleaudiology-master")
//							{
//								Excel_FlagKey2.Add(j);
//								Excel_BrandValues2.Add(_key2);
//								Excel_FlagKey2.Add("teleaudiology-video-fsw");
//								Excel_BrandValues2.Add(_key2);
//								Excel_FlagKey2.Add("teleaudiology-fitting-fsw");
//								Excel_BrandValues2.Add(_key2);
//								Excel_FlagKey2.Add("teleaudiology-tsgrestricted-fsw");
//								Excel_BrandValues2.Add(_key2);
//							}
//							else
//							{
						Excel_FlagKey2.Add(j);
						Excel_BrandValues2.Add(_key2);
						//	}
					}
				}
				
				
				workBook.Close(0);
				application.Quit();
				//	}
			}
			
			else if(Buildname_ExcelValues.Contains("SolusMax"))
			{
//				if(Marketname=="United States")
//				{
//					string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Bohrium_4_Feature Flags.xlsx";
//					Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
//					XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
//
//					Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[2];
//					Excel.Worksheet worksheet2 = (Excel.Worksheet)workBook.Worksheets[3];
//					for(int i=3;i<=10;i++)
//					{
//						object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 1]).Value;
//						if(cellValue !=null)
//						{
//							string j=cellValue.ToString();
//							j=j.Trim();
//							if(j != "teleaudiology-master")
//							{
//								Excel_FlagKey2.Add(j);
//								object KeyValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 4]).Value;
//								string _key=KeyValue.ToString();
//								_key=_key.Trim();
//								Excel_BrandValues2.Add(_key);
//							}
//						}
//					}
//
//					for(int j=2;j<=5;j++)
//					{
//						object KeyValue2 = ((Microsoft.Office.Interop.Excel.Range)worksheet2.Cells[j, 4]).Value;
//						object cellValue2 = ((Microsoft.Office.Interop.Excel.Range)worksheet2.Cells[j, 1]).Value;
//						if(cellValue2 !=null)
//						{
//							string k=cellValue2.ToString();
//							k=k.Trim();
//							Excel_FlagKey2.Add(k);
//							string _key2=KeyValue2.ToString();
//							_key2=_key2.Trim();
//							Excel_BrandValues2.Add(_key2);
//						}
//					}
//					workBook.Close(0);
//					application.Quit();
//
//				}
//				else
//				{
				string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Bohrium_4_Feature Flags.xlsx";
				Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
				XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
				Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[2];
				for(int i=3;i<=21;i++)
				{
					object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 1]).Value;
					object KeyValue2 = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 4]).Value;
					if(cellValue !=null)
					{

						string j=cellValue.ToString();
						j=j.Trim();
						string _key2=KeyValue2.ToString();
						_key2=_key2.Trim();
						
//							if(j=="teleaudiology-master")
//							{
//								Excel_FlagKey2.Add(j);
//								Excel_BrandValues2.Add(_key2);
//								Excel_FlagKey2.Add("teleaudiology-video-fsw");
//								Excel_BrandValues2.Add(_key2);
//								Excel_FlagKey2.Add("teleaudiology-fitting-fsw");
//								Excel_BrandValues2.Add(_key2);
//								Excel_FlagKey2.Add("teleaudiology-tsgrestricted-fsw");
//								Excel_BrandValues2.Add(_key2);
//							}
//							else
//							{
						Excel_FlagKey2.Add(j);
						Excel_BrandValues2.Add(_key2);
						//	}
					}
				}
				
				
				workBook.Close(0);
				application.Quit();
				//	}
			}
			
		}
		[UserCodeMethod]
		public static void Excel_FlagKeyMethod(string Marketname,string BuildnameExcelKey)
		{
			Excel_FlagKey.Clear();
			if(BuildnameExcelKey.Contains("SmartFit"))
			{
				if(Marketname=="United States")
				{
					
					//	string excelFinalPath = @"C:\Users\i-ray\Desktop\Copy of Feature Flags Radon2_rev.03.xlsx";
					string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Feature Flags Radon2_rev.03.xlsx";
					Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
					XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
					
					Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[2];
//				using (System.IO.StreamWriter file =
//				       new System.IO.StreamWriter(@"C:\Users\i-ray\Documents\Feature_Flags_Excel.txt"))
					for(int i=3;i<=30;i++)
					{
						
						object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 1]).Value;
						
						string j=cellValue.ToString();
						
						j=j.Trim();

						Excel_FlagKey.Add(j);
						//	file.WriteLine(j);
						
					}
					workBook.Close(0);
					application.Quit();
				}
				else
				{
					
					string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Feature Flags Radon2_rev.03.xlsx";
					Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
					XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
					
					Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[3];

					for(int i=3;i<=30;i++)
					{
						
						object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 1]).Value;
						
						string j=cellValue.ToString();
						
						j=j.Trim();

						Excel_FlagKey.Add(j);
						
						
					}
					workBook.Close(0);
					application.Quit();
				}
			}
			else if(BuildnameExcelKey.Contains("SolusMax"))
			{
				if(Marketname=="United States")
				{
					string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Feature Flags Radon2_rev.03.xlsx";
					Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
					XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
					
					Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[2];

					for(int i=3;i<=30;i++)
					{
						
						object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 1]).Value;
						
						string j=cellValue.ToString();
						
						j=j.Trim();

						Excel_FlagKey.Add(j);
						
						
					}
					workBook.Close(0);
					application.Quit();
				}
				else
				{
					
					string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Feature Flags Radon2_rev.03.xlsx";
					Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
					XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
					
					Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[3];
					for(int i=3;i<=30;i++)
					{
						
						object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 1]).Value;
						
						string j=cellValue.ToString();
						
						j=j.Trim();

						Excel_FlagKey.Add(j);
						
					}
					workBook.Close(0);
					application.Quit();
				}
			}
		}
		
		[UserCodeMethod]
		public static void Excel_BrandValuesMethod(string Marketname,string Buildname_ExcelValues)
		{
			Excel_BrandValues.Clear();
			if(Buildname_ExcelValues.Contains("SmartFit"))
			{
				if(Marketname=="United States")
				{
					
					string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Feature Flags Radon2_rev.03.xlsx";
					Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
					XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
					
					Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[2];

					for(int i=3;i<=30;i++)
					{
						
						object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 3]).Value;
						Excel_BrandValues.Add(cellValue.ToString());
						
					}
					workBook.Close(0);
					application.Quit();
				}
				else
				{
					Excel_BrandValues.Clear();
					string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Feature Flags Radon2_rev.03.xlsx";
					Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
					XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
					
					Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[3];

					for(int i=3;i<=30;i++)
					{
						
						object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 3]).Value;
						Excel_BrandValues.Add(cellValue.ToString());
						
					}
					workBook.Close(0);
					application.Quit();
				}
			}
			else if(Buildname_ExcelValues.Contains("SolusMax"))
			{
				if(Marketname=="United States")
				{
					
					string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Feature Flags Radon2_rev.03.xlsx";
					Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
					XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
					
					Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[2];

					for(int i=3;i<=30;i++)
					{
						
						object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 5]).Value;
						Excel_BrandValues.Add(cellValue.ToString());
						
					}
					workBook.Close(0);
					application.Quit();
				}
				else
				{
					Excel_BrandValues.Clear();
					string excelFinalPath = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Feature Flags Radon2_rev.03.xlsx";
					Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
					XLS.Workbook workBook = application.Workbooks.Open(excelFinalPath);
					
					Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Worksheets[3];

					for(int i=3;i<=30;i++)
					{
						
						object cellValue = ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i, 5]).Value;
						Excel_BrandValues.Add(cellValue.ToString());
						
					}
					workBook.Close(0);
					application.Quit();
				}
				
			}
			
		}
		
		
		[UserCodeMethod]
		public static void Compare_Xml_And_Excel_Methods(string MarketName)
		{

			if(MarketName=="United States")
			{
				for(int i=0;i<=Excel_FlagKey.Count-1;i++)
				{
					for(int j=0;j<=XMl_FlagKey.Count-1;j++)
					{
						if(Excel_FlagKey[i]==XMl_FlagKey[j])
						{
							if(XMl_FlagKey[j]=="teleaudiology-master" || XMl_FlagKey[j]=="teleaudiology-video-fsw" ||XMl_FlagKey[j]=="teleaudiology-fitting-fsw" || XMl_FlagKey[j]=="teleaudiology-tsgrestricted-fsw")
							{

								
							}
							else if(XMl_FlagValues[j].Contains("True") && Excel_BrandValues[i].Contains("ON"))
							{
								
								Report.Success("Pass :"+Excel_FlagKey[i]+ "-  True "+ "= "+ " ON ");
							}
							else if(XMl_FlagValues[j].Contains("False") && Excel_BrandValues[i].Contains("OFF"))
							{
								
								Report.Success("Pass :"+Excel_FlagKey[i]+ "-  False "+ "= "+ " OFF ");
							}
							else
							{
								Report.Failure("Fail :"+Excel_FlagKey[i]);
							}
							
						}
						
						
					}
					for(int k=0;k<=XMl_FlagKey_US.Count-1;k++)
					{
						if(Excel_FlagKey[i]==XMl_FlagKey_US[k])
						{
							if(XMl_FlagKey_US[k]=="teleaudiology-master" || XMl_FlagKey_US[k]=="teleaudiology-video-fsw" ||XMl_FlagKey_US[k]=="teleaudiology-fitting-fsw" || XMl_FlagKey_US[k]=="teleaudiology-tsgrestricted-fsw")
							{
								if(XMl_FlagValues_US[k].Contains("True") && Excel_BrandValues[i].Contains("ON"))
								{
									Report.Success("Pass :"+Excel_FlagKey[i]+ "-  True "+ "= "+ " ON ");
								}
								else
								{
									Report.Failure("Fail :"+Excel_FlagKey[i]);
								}

							}
						}
					}
					
				}
				
			}
			
			else
			{
				for(int i=0;i<=Excel_FlagKey.Count-1;i++)
				{
					for(int j=0;j<=XMl_FlagKey.Count-1;j++)
					{
						if(Excel_FlagKey[i]==XMl_FlagKey[j])
						{

							if(XMl_FlagValues[j].Contains("True") && Excel_BrandValues[i].Contains("ON"))
							{
								
								Report.Success("Pass :"+Excel_FlagKey[i]+ "-  True "+ "= "+ " ON ");
							}
							else if(XMl_FlagValues[j].Contains("False") && Excel_BrandValues[i].Contains("OFF"))
							{
								
								Report.Success("Pass :"+Excel_FlagKey[i]+ "-  False "+ "= "+ " OFF ");
							}
							else
							{
								Report.Failure("Fail :"+Excel_FlagKey[i]);
							}
							
						}
					}
				}
				
				
			}
			
		}
		
		[UserCodeMethod]
		public static void DeleteFiles(string DeleteBuildname)
		{
			if(DeleteBuildname.Contains("SmartFit"))
			{
				String sPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				String sPath2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				string fileName = @"Beltone\";
				string filename2=@"Temp";
				string path=Path.Combine(sPath,fileName);
				if(System.IO.Directory.Exists(path))

				{
					
					
					System.IO.Directory.Delete(path,true);
				}
				
				
				string path2=Path.Combine(sPath2,filename2);
				if(System.IO.Directory.Exists(path2))
				{
					try
					{

						System.IO.Directory.Delete(path2, true);
						
					}

					catch
					{
						
					}
				}
				
				if(System.IO.Directory.Exists(@"C:\ProgramData\GN\"))
				{
					
					try
					{
						System.IO.Directory.Delete(@"C:\ProgramData\GN", true);
						
					}

					catch
					{
						
					}
				}
				if(System.IO.Directory.Exists(@"C:\ProgramData\FLEXnet\"))
				{
					
					try
					{
						System.IO.Directory.Delete(@"C:\ProgramData\FLEXnet", true);
						
					}

					catch
					{
						
					}
				}
				if(System.IO.Directory.Exists(@"C:\ProgramData\ReSound\Aventa\"))
				{
					
					try
					{
						System.IO.Directory.Delete(@"C:\ProgramData\ReSound\Aventa", true);
						
					}

					catch
					{
						
					}
				}
				
				
//				if(System.IO.Directory.Exists(@"C:\ProgramData\ReSound\Aventa\"))
//				{
//
//					System.IO.Directory.Delete(@"C:\ProgramData\ReSound\Aventa", true);
//				}
				
				if(System.IO.Directory.Exists(@"C:\Program Files (x86)\ReSound\Common\"))
				{
					try
					{
						System.IO.Directory.Delete(@"C:\Program Files (x86)\ReSound\Common", true);
					}
					catch
					{
						
					}
				}
				if(System.IO.Directory.Exists(@"C:\Program Files (x86)\ReSound\Merlin\"))
				{
					try
					{
						System.IO.Directory.Delete(@"C:\Program Files (x86)\ReSound\Merlin", true);
					}
					catch
					{
						
					}
				}
				
				
				
				if(System.IO.Directory.Exists(@"C:\ProgramData\ReSound\Fuse2\"))
				{
					
					System.IO.Directory.Delete(@"C:\ProgramData\ReSound\Fuse2", true);
				}
				if(System.IO.Directory.Exists(@"C:\ProgramData\ReSound\SmartFit\"))
				{
					
					System.IO.Directory.Delete(@"C:\ProgramData\ReSound\SmartFit", true);
				}
				
				
//				if(System.IO.Directory.Exists(@"C:\Program Files (x86)\GN Hearing\"))
//				{
//					try
//					{
//						System.IO.Directory.Delete(@"C:\Program Files (x86)\GN Hearing", true);
//
//					}
//
//					catch
//					{
//
//					}
//				}
//				if(System.IO.Directory.Exists(@"C:\Program Files (x86)\GN ReSound\"))
//				{
//
//					try
//					{
//						System.IO.Directory.Delete(@"C:\Program Files (x86)\GN ReSound", true);
//
//					}
//
//					catch
//					{
//
//					}
//				}
//				if(System.IO.Directory.Exists(@"C:\Program Files (x86)\ReSound\Aventa3\"))
//				{
//
//					try
//					{
//						System.IO.Directory.Delete(@"C:\Program Files (x86)\ReSound\Aventa3", true);
//
//					}
//
//					catch
//					{
//
//					}
//				}

				if(System.IO.Directory.Exists(@"C:\Program Files (x86)\ReSound\SmartFit\"))
				{
					
					try
					{
						System.IO.Directory.Delete(@"C:\Program Files (x86)\ReSound\SmartFit", true);
						
					}

					catch
					{
						
					}
				}
			}
			else if(DeleteBuildname.Contains("SolusMax"))
			{
				
				String sPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				String sPath2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				string fileName = @"Beltone\";
				string filename2=@"Temp";
				string path=Path.Combine(sPath,fileName);
				if(System.IO.Directory.Exists(path))

				{
					
					
					System.IO.Directory.Delete(path,true);
				}
				
				
				string path2=Path.Combine(sPath2,filename2);
				if(System.IO.Directory.Exists(path2))
				{
					try
					{

						System.IO.Directory.Delete(path2, true);
						
					}

					catch
					{
						
					}
				}
				if(System.IO.Directory.Exists(@"C:\ProgramData\GN\"))
				{
					
					try
					{
						System.IO.Directory.Delete(@"C:\ProgramData\GN", true);
						
					}

					catch
					{
						
					}
				}
				if(System.IO.Directory.Exists(@"C:\ProgramData\Beltone\"))
				{
					
					try
					{
						System.IO.Directory.Delete(@"C:\ProgramData\Beltone", true);
						
					}

					catch
					{
						
					}
				}
				
				
				
				
				
				if(System.IO.Directory.Exists(@"C:\Program Files (x86)\Beltone\Common\"))
				{
					
					try
					{
						System.IO.Directory.Delete(@"C:\Program Files (x86)\Beltone\Common", true);
						
					}
					
					catch
					{
						
					}
				}
				if(System.IO.Directory.Exists(@"C:\Program Files (x86)\Beltone\SolusMax\"))
				{
					
					try
					{
						System.IO.Directory.Delete(@"C:\Program Files (x86)\Beltone\SolusMax", true);
						
					}
					
					catch
					{
						
					}
				}
				

//				if(System.IO.Directory.Exists(@"C:\Program Files (x86)\Beltone\"))
//				{
//
//					try
//					{
//						System.IO.Directory.Delete(@"C:\Program Files (x86)\Beltone", true);
//
//					}
//
//					catch
//					{
//
//					}
//				}
			}
		}
		
		
		[UserCodeMethod]
		public static void Uninstall(string UninstallBuildname)
		{
			Process p = new Process();
			Delay.Seconds(3);
			//	p.StartInfo.FileName = @"C:\Builds\"+UninstallBuildname+"\\Setup.exe";
			p.StartInfo.FileName = @"D:\TFS\FSW\TestSuites\FeatureFlag_Validation\Builds\"+UninstallBuildname+"\\Setup.exe";
			p.StartInfo.Arguments = "/x /v/qn";
			p.Start();
			Delay.Seconds(5);
		}
		
	}
}
