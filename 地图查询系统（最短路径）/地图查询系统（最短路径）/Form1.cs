using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 地图查询系统_最短路径_
{
    public partial class Form1 : Form
    {
        const int maxn = 50;
        const int INF = 10000000;
        public static String[] city = 
        {                          
"苹果园","古城路","八角公园","八宝山","玉泉路","五棵松","万寿路","公主坟","军事博物馆","木据地","南礼士路","复兴门","西单",
"天安门西","天安门东","王府井","东单","建国门","永安里","国贸","大望路","四惠","四惠东","北京西站","白锥子","四道口","白石桥",
"龙背村","颐和园","圆明园","成府路","中关村","黄庄","学院南路","动物园","西直门","新街口","平安里","西四","灵境胡同","宣武门",
"菜市口","北京南站","积水潭","车公庄","阜成门","长椿街","前门","崇文门","北京站"
        };
        int l1 = 23;
        int l9 = 5;
        int l4 = 18;
        int l2 = 11;
        int[] Line1 = { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22};
        int[] Line9 = {23,8,24,25,26 };
        int[] Line4 = { 27,28,29,30,31,32,33,26,34,35,36,37,38,39,12,40,41,42};
        int[] Line2 = { 43,35,44,45,11,46,40,47,48,49,17};
        int[] d = new int[maxn];
        public static int[] num = new int[maxn + 1];
        public static int tot = 0;
        int TransferNum=0;
        public static int[,] distance = 
{ 
//苹果园 
{INF,2,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//古城路
{2,INF,2,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//八角公园
{INF,2,INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//八宝山
{INF,INF,3,INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//玉泉路
{INF,INF,INF,3,INF,2,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//五棵松
{INF,INF,INF,INF,2,INF,2,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//万寿路
{INF,INF,INF,INF,INF,2,INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//公主坟
{INF,INF,INF,INF,INF,INF,3,INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//军事博物馆
{INF,INF,INF,INF,INF, INF,INF,3,INF,2, INF,INF,INF,INF,INF, 	INF,INF,INF,INF,INF,	 INF,INF,INF,3,3, 	INF,INF,INF,INF,INF, 	INF,INF,INF,INF,INF, 	INF,INF,INF,INF,INF, 	INF,INF,INF,INF,INF, 	INF,INF,INF,INF,INF},
//木据地
{INF,INF,INF,INF,INF,INF,INF,INF,2,INF,1,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//南礼士路
{INF,INF,INF,INF,INF,INF,INF,INF,INF,1,INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//复兴门
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,3,INF,2,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,3,3,INF,INF,INF},
//西单
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,2,INF,2,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,3, 3,INF,INF,INF,INF, INF,INF,INF,INF,INF},
//天安门西
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,2,INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//天安门东
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,3,INF,2,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//王府井
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,2,INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//东单
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,3,INF,2,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,3,INF},
//建国门
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,2,INF,2,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,3},
//永安里
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,2,INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//国贸
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,3,INF,2,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//大望路
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,2,INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//四惠
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,3,INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//四惠东
{INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//北京西站
{INF,INF,INF,INF,INF,	INF,INF,INF,3,INF,	INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//白锥子
{INF,INF,INF,INF,INF,	INF,INF,INF,3,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	3,INF,INF,INF,INF,	INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//四道口
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,3,	INF,3,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF,INF},
//白石桥
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	3,INF,INF,INF,INF,	INF,INF,INF,3,3,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//龙背村
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,4,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//颐和园
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,4,INF,3,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,INF},
//圆明园
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,3,INF,	2,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//成府路
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,2,INF,3,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//中关村
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,3,INF,3,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//黄庄
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,INF,3,INF,3,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//学院南路
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,3,INF,INF,INF,	INF,INF,3,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//动物园
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,3,INF,INF,INF,	INF,INF,INF,INF,INF,	3,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//西直门
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,3,	INF,3,INF,INF,INF,	INF,INF,INF,3,3,	INF,INF,INF,INF,INF},
//新街口
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	3,INF,3,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//平安里
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,3,INF,3,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//西四
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,3,INF,3,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//灵境胡同
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,3,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,3,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//宣武门
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,3,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,3,INF,INF,INF,	INF,3,3,INF,INF},
//菜市口
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	3,INF,5,INF,INF,	INF,INF,INF,INF,INF},
//北京南站
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,5,INF,INF,INF,	INF,INF,INF,INF,INF},
//积水潭
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	3,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//车公庄
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	3,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	3,INF,INF,INF,INF},
//阜成门
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,3,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,3,	INF,INF,INF,INF,INF},
//长椿街
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,3,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	3,INF,INF,INF,INF,	INF,INF,INF,INF,INF},
//前门
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	3,INF,INF,INF,INF,	INF,INF,INF,3,INF},
//崇文门
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,3,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,3,INF,3},
//北京站
{INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,3,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,INF,INF,	INF,INF,INF,3,INF}
};
  //      int[,] path = new int[maxn, maxn];
        int []fa=new int [maxn];
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < maxn; i++)
            {
                comboBox1.Items.Add(city[i]);
            }
            for (int i = 0; i < maxn; i++)
            {
                comboBox2.Items.Add(city[i]);
            }
            time.Text = DateTime.Now.ToString("h:mm:ss");
            timer1.Enabled = true;
            timer1.Interval = 100;
        }
        private bool iflegal_1()
        {
            if (comboBox1.Text != "")
            {
                if (comboBox1.Items.Contains(comboBox1.Text))
                {
                    return true;
                }
            }
            return false;
        }
        private bool iflegal_2()
        {
            if (comboBox2.Text != "")
            {
                if (comboBox2.Items.Contains(comboBox2.Text))
                {
                    return true;
                }
            }
            return false;
        }
        private int find(int x,int y)
        {
            bool flag1 = false;
            bool flag2 = false;
            for (int i = 0; i < l1; i++)
            {
                if (x == Line1[i])
                {
                    flag1 = true;
                }
                if (y == Line1[i])
                {
                    flag2 = true;
                }
            }
            if (flag1 && flag2)
            {
                return 1;
            }
            flag1 = flag2 = false;
            for (int i = 0; i < l9; i++)
            {
                if (x == Line9[i])
                {
                    flag1 = true;
                }
                if (y == Line9[i])
                {
                    flag2 = true;
                }
            }
            if (flag1 && flag2)
            {
                return 9;
            }
            flag1 = flag2 = false;
            for (int i = 0; i < l4; i++)
            {
                if (x == Line4[i])
                {
                    flag1 = true;
                }
                if (y == Line4[i])
                {
                    flag2 = true;
                }
            }
            if (flag1 && flag2)
            {
                return 4;
            }
            flag1 = flag2 = false;
            for (int i = 0; i < l2; i++)
            {
                if (x == Line2[i])
                {
                    flag1 = true;
                }
                if (y == Line2[i])
                {
                    flag2 = true;
                }
            }
            if (flag1 && flag2)
            {
                return 2;
            }
            return -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TransferNum = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            int a,b,c,k = 0;
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请输入起始点！");
                return;
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("请输入终点！");
                return;
            }
            if (!iflegal_1())
            {
                MessageBox.Show("查无该起始点！");
                return;
            }
            if (!iflegal_2())
            {
                MessageBox.Show("查无该终点！");
                return;
            }
            for (c = 0; c < maxn && city[c] != comboBox1.Text; c++) ;
            a = c;
            for (c = 0; c < maxn && city[c] != comboBox2.Text; c++) ;
            b = c;
            ShortestPath(a, b);
            tot = 0;
            k=b;
            while (k != -1)
            {
                num[tot++] = k;
                k = fa[k];
            }
            String mypath="";
            String subwaypath = "";
            k=tot-1;
            int x = num[k];
            int ans = 0;
            int pre = 0;
            if (k - 1 >= 0)
            {
                ans = find(x,num[k-1]);
                mypath += "（乘坐" + ans.ToString() + "号线） ";
                subwaypath += "("+city[x]+")"+ans.ToString() + "号线";
            }
            mypath = mypath + city[x];
            k--;
            while (k>=1)
            {
                pre = ans;
                ans = find(num[k],num[k-1]);
                mypath = mypath + "->";
                if (pre != ans)
                {
                    mypath += "（换乘" + ans.ToString() + "号线） ";
                    subwaypath += "->" + "(" + city[num[k]] + ")" + ans.ToString() + "号线";
                    TransferNum++;
                }
                mypath=mypath+city[num[k]];
                k--;
            }
            mypath = mypath + "->";
            mypath = mypath + city[b];
            subwaypath += "->"+city[b];
            textBox2.Text = d[b].ToString();
            textBox1.Text = mypath;
            label9.Text = TransferNum.ToString();
            label11.Text = subwaypath;
        }
        private void ShortestPath(int a,int b)//采用Dijkstra算法
        {
            bool[] visit = new bool[maxn];
            for (int i = 0; i < maxn; i++)
            {
                fa[i] = -1;
            }
            for (int v = 0; v < maxn; v++)
            {
                visit[v] = false;
                d[v] = INF;
            }
            d[a] = 0;
            for (int i = 0; i < maxn; i++)
            {
                int x=0, min = INF;
                for (int y = 0; y < maxn; y++)
                {
                    if (!visit[y] && d[y] <= min)
                    {
                        x = y;
                        min=d[y];
                    }
                }
                visit[x] = true;
                for (int y = 0; y < maxn; y++)
                {
                    if (d[y] > d[x] + distance[x,y])
                    {
                        d[y] = d[x] + distance[x, y];
                        fa[y] = x;
                    }
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("h:mm:ss");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2();
            child.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 child = new Form3();
            child.Show();
        }
    }
}

