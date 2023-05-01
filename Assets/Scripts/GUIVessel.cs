using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;
using System.Reflection;


public class GUIVessel : MonoBehaviour
{
    [System.NonSerialized]
    public UnitySerialPort data;
 
    private float bt1, bt2, bt3, bt4;
    private float tempPos;

	public bool ModeMaterial = false;

    //-----------------------------
    public string editHodl1P = "sensor hold 1p";


		private WMG_Series shearline_series, bmomentLine_series, loadline_series;
		public GameObject[] doubleBottom;
  
		//chart transversal
		public List<Vector2> pointSeries0;
		public List<Vector2> pointSeries1;
		public List<Vector2> pointSeries2;
		public List<Vector2> pointSeries3;
		public List<Vector2> pointSeries4;
		public List<Vector2> pointSeries5;
		public List<Vector2> pointSeries6;
		public List<Vector2> pointSeries7;
		public List<Vector2> pointSeries8;
		public List<Vector2> pointSeries9;
		public List<Vector2> pointSeries10;
		public List<Vector2> pointSeries11;
        public List<Vector2> pointSeries25;
        public List<Vector2> pointSeries26;
		//------------

		//chart Longitudinal
		public List<Vector2> pointSeries12;
		public List<Vector2> pointSeries13;
		public List<Vector2> pointSeries14;
		public List<Vector2> pointSeries15;
		public List<Vector2> pointSeries16;
		public List<Vector2> pointSeries17;
		public List<Vector2> pointSeries18;
		public List<Vector2> pointSeries19;
		public List<Vector2> pointSeries20;
		public List<Vector2> pointSeries21;
		public List<Vector2> pointSeries22;
		public List<Vector2> pointSeries23;
		public List<Vector2> pointSeries24;

        public List<Vector2> pointSeries27;
        public List<Vector2> pointSeries28;

    //Hydrostatic Curve Point Series
        public List<Vector2> sLCB, sLCF, sMCTC, sKBt, sKMt, sCp, sCb, sDisp, sTPC;


		// BALLAST MODE SELECTOR
		public string[] BallastModeItems;
		public Rect Box;
		public string BallastselectedItem = "Manual";
		private bool editing = false;
		private int BallastMode = 0;
		private int ballastModeData;
		public Transform labelDB;

		//-----------------------------------
		private int cont;
       

        public float m_cont = 160f;//bobot container 160gr
        public float m_contLama;
      

        

        private float _d;
        private float _tF;
        private float _tA;
        private float tPos;
        private float KG1;
        private float CLP;
        private float G1MT;
        private float G1G2;


        private float _tFAwal = 66f;
        private float _tAAwal = 76f;

        private float _tTrim;
        private float _trimAwal;
        private float _list;


        private float momentTBay;
        private float momentTRow;
        private float momentTTier;
        
        private float tmpPosBay;
        private float tmpPosRow;
        private float tmpPosTier;
    
        private float mPosBay;
        private float mPosRow;
        private float mPosTier;

        public float dispTotal;
        public float Ftot = 0;
        public float BobotTotal = 0;
        public float _BobotTotal = 0;
        public float jumCon = 0;//from input manual
        public float jumConAI = 0;//from AI
        public float _JumCon = 0;//all
        public float TempList;
        public float TempTrim;
        public float temp_yCG;
        public float temp_zCG;
        private float VoltPort1 = 0, VoltPort2 = 0, VoltPort3 = 0, VoltPort4 = 0,
                        VoltStar1 = 0, VoltStar2 = 0, VoltStar3 = 0, VoltStar4 = 0;
        private float VoltTotal = 0;
        public float Gmx, Gmy;

        //titik pusat seluruh muatan (20150826)
        private float Bx1, Bx3, Bx5, Bx7, Bx9, Bx11, Bx13, Bx15;//(posisi bay)
        private float Ry0, Ry1, Ry2, Ry3, Ry4;//(posisi row)
        private float BayPos1, BayPos3, BayPos5, BayPos7, BayPos9, BayPos11, BayPos13, BayPos15;
        private float RowPos0, RowPos1, RowPos2, RowPos3, RowPos4;
        private float mArahX1, mArahX3;
        private float tMomentX;
        private float jumConB1,jumConB3;




		//-----------------------------------

		//-------DRAFT VARIABLE
		private float Draft_1P,
				Draft_2P,
				Draft_3P;
		private float Draft_1SB,
				Draft_2SB,
				Draft_3SB;
		private float D1P;
		private float D2P;
		private float D1S;
		private float D2S;
		private float F1, F2, F3, F4;

		//-------WATER BALLAST VAR
		private float WBL1P,
				WBL2P,
				WBL3P,
				WBL4P,
				WBL5P;
		private float WBL1SB,
				WBL2SB,
				WBL3SB,
				WBL4SB,
				WBL5SB;

        public float posYShip;
        public float posYShipM;

		//--------------var for sensor	input
		private float Hold1_1P;// = 0.0f;
		private float Hold1_2P;// = 0.0f;
		private float Hold1_1SB;// = 0.0f;
		private float Hold1_2SB;//= 0.0f;

		private float Hold2_1P = 0.0f;
		private float Hold2_2P = 0.0f;
		private float Hold2_1SB = 0.0f;
		private float Hold2_2SB = 0.0f;
		private float Hold3_1P = 0.0f;
		private float Hold3_2P = 0.0f;
		private float Hold3_1SB = 0.0f;
		private float Hold3_2SB = 0.0f;
		private float Hold4_1P = 0.0f;
		private float Hold4_2P = 0.0f;
		private float Hold4_1SB = 0.0f;
		private float Hold4_2SB = 0.0f;
		private float Hold5_1P = 0.0f;
		private float Hold5_2P = 0.0f;
		private float Hold5_1SB = 0.0f;
		private float Hold5_2SB = 0.0f;

		//---ARM FORCE
		private float AF1P;
		private float AF2P;
		private float AF1SB;
		private float AF2SB;

		//------------------------------------------

		//------level akuarium
		private float lvAkuariumF;
		private float lvAkuariumB;

		//-------float bottom LOW
		private float DB_1P_L = 0.0f;
		private float DB_2P_L = 0.0f;
		private float DB_3P_L = 0.0f;
		private float DB_4P_L = 0.0f;
		private float DB_1SB_L = 0.0f;
		private float DB_2SB_L = 0.0f;
		private float DB_3SB_L = 0.0f;
		private float DB_4SB_L = 0.0f;

		//-------float bottom HIGH
		private float DB_1P_H = 0.0f;
		private float DB_2P_H = 0.0f;
		private float DB_3P_H = 0.0f;
		private float DB_4P_H = 0.0f;
		private float DB_1SB_H = 0.0f;
		private float DB_2SB_H = 0.0f;
		private float DB_3SB_H = 0.0f;
		private float DB_4SB_H = 0.0f;

		//---DOUBLE BOTTOM

		private float DB_1P = 0.0f;
		private float DB_2P = 0.0f;
		private float DB_3P = 0.0f;
		private float DB_4P = 0.0f;
		private float DB_1SB = 0.0f;
		private float DB_2SB = 0.0f;
		private float DB_3SB = 0.0f;
		private float DB_4SB = 0.0f;


		//----variabel BRT continer
		public string[] itemBay;
		private string selectedBay = "";
		private bool editingA = false;
		public string[] itemRow;
		private string selectedRow = "";
		private bool editingB = false;
		public string[] itemTeir;
		private string selectedTeir = "";
		private bool editingC = false;
		private float posBay;
		private float posRow;
		private float posTeir;
		public Transform container1, container2, container3, container4,cont_sim;
		private string message = "";
        public GameObject laut;


    //-------stack
        public float jStack;
        private float tmpStack;

	//----------posisi form
	private Rect frmBRT = new Rect(Screen.width * 1.7f / 2 - (Screen.width / 2), Screen.height * 2.165f / 2 - (Screen.height / 2), 480, 325);

	//private Rect frmBRT = new Rect(Screen.width * 1f / 1 - (Screen.width / 1), Screen.height * 1f / 2 - (Screen.height / 2), 410, 325);

	private Rect frmViewInfo = new Rect(Screen.width * 1.15f / 2 - (Screen.width / 2), Screen.height * 2.55f / 2 - (Screen.height / 2), 900, 160);

		private Rect frmCalib = new Rect (Screen.width * 2.21f / 2 - (Screen.width / 2), Screen.height * 1.26f / 2 - (Screen.height / 2), 550, 770);
        private Rect frmSimulasi = new Rect(Screen.width * 1.5f / 2 - (Screen.width / 2), Screen.height * 1.26f / 2 - (Screen.height / 2), 530, 550);
		private Rect frmChart = new Rect (Screen.width / 2 - (Screen.width * 0.74f / 2), Screen.height / 2 - (Screen.height * 0f / 2), 1120, 300);
        private Rect frmMode = new Rect(Screen.width * 1.88f / 2 - (Screen.width / 2), Screen.height * 1.26f / 2 - (Screen.height / 2), 230, 83);
        private Rect frmExit = new Rect(Screen.width * 2.58f / 2 - (Screen.width / 2), Screen.height * 1.26f / 2 - (Screen.height / 2), 230, 83);
		private Rect frmMenu = new Rect (Screen.width / 2 - (Screen.width * 0.42f / 2), Screen.height / 2 - (Screen.height * 0.5f / 2), 1200, 90);
        private Rect frmHelp = new Rect(Screen.width * 2.32f / 2 - (Screen.width / 2), Screen.height * 1.26f / 2 - (Screen.height / 2), 350, 200);
		//-----------------------------------

		public GameObject shipMode;//
		public GameObject shipVessel;
		public Material shader1;//shader solid
		public Material shader2;//shader transparan

		//-----------beban
		private float minIn = 0.0f;
		private float maxIn = 5.0f;
		private float wBeban = -200;
		//-------------------------------------
		private float maxAngleL = 5.0f;
		private float minAngleL = 0.0f;
		private float maxAngleT = 5.0f;
		private float minAngleT = 0.0f;
		public float sldTrim;
		public float sldList;
		private float TrimVal;
		private float ListVal;


    //---3 feb 2015
        private float vTier;
        private float sldTier = 0.0f;
        private float minTier = 0.0f;
        private float maxTier = 5.0f;


		private string btnSimulation = "Simulation";
		private bool menuSim = false;
		private bool menuCalib = false;
		private bool menuMode = false;
		private bool menuExit = false;
		private bool menuChart = false;
		public bool menuInput = false;
        private bool menuHelp = false;
		private bool menuBallastMode = false; // MENU BALLAST MODE
        private bool menuInfo = false;


		//-----------------------WATER BALLAS LOW & HIGHT
		private float FLBWB1P, FLBWB2P, FLBWB3P;
		private float FLBWB1SB, FLBWB2SB, FLBWB3SB;
		private float FLAB;
		private float FLFB;
		private float FLFWTP;
		private float FLFWTF;
		private float FHBWB1P, FHBWB2P, FHBWB3P;
		private float FHBWB1SB, FHBWB2SB, FHBWB3SB;
		private float FHAB;
		private float FHFB;
		private float FHFWTP;
		private float FHFWTF;
        private string btnInfo="InfoX";


		//private float FHFWTF;

		private float FCFB;
		private float FCAB;
		private float draft;
		float btnHeight = 35;
		float btWidth = 100;
		private float draftTotal;
		private float KG, KM, KB, KB_rot;
		private bool sdhTaruh;
		private float jLama, jBaru;

		//----jcon
		private float jLama1;
		private float jLama2;
		private float jLama3;
		private float jLama4;
		//---------------

		private Transform _child;
		private float H1, H2, H3, H4;
		private float jTotal;
		private float jCon;//jumlah total kontener
		private float jCon1, jCon2, jCon3, jCon4;

		//data konstan
		private float wKosong = 14.0f;
		private float pKapal = 1.96f;
		private float length_hold1 = 0.68f;
		private float length_hold2 = 0.57f;
		private float length_hold3 = 0.34f;
		private float length_hold4 = 0.37f;
		private float tMuatan;
		private float gApung;
		private float wKosongMeter;
		private float gH1, gH2, gH3, gH4;
		public float kgData; // KG Data

		private float[] xWL;
		private float[] yWL;
		public Camera camMain;
		public GameObject camChart;
		public GameObject Port;
		public GameObject chart2d;
		private float tH1, tH2, tH3, tH4, totalH;
		private float lvDraft;
		
		private float posX = 280;
		private float dInput1 = 0.0f;
		public float dOutput1 = 0.0f;
		public float dDisp = 0.0f;
        
		private float scale_ld = 100; // scale for load distribution, graph drawing purpose
		private float scale_sf = 250; // scale for shear force, graph drawing purpose
		private float scale_bm = 550; // scale for bending moment, graph drawing purpose


        public float dDispVal = 0;   // displacement value in kgf
        public float dHeelVal = 0;   // heel angle in deg
        public float dTrimVal = 0;   // trim angle in deg, 20150822
        public float dGZVal = 0;     // GZ value in mm
        public float dKNVal = 0;     // KN value in mm
        public float dKBTVal = 0;    // KB transversal value in mm
        public float dKMTVal = 0;    // KM transversal value in mm
        public float dTCBVal = 0;    // CB transversal value in mm
        public float dDraftVal = 0;  // draft value in mm
        public float dInputVal = 0;  // Input value = Displacement or Draft
        public float dOutputVal = 0; // Output value = Displacement or Draft
        public float dPitchVal = 0;  // pitch angle in deg, pitch = -trim, 20140919
        public float dTCGVal = 0;
        public float dLCGVal = 0;

        public float dKBLVal = 0;    // KB longitudinal value in mm
        public float dKMLVal = 0;    // KM longitudinal value in mm
        public float dLCBVal = 0;    // CB longitudinal value in mm
        public float dLCFVal = 0;    // LCF longitudinal value in mm 
        public float dKCFVal = 0;    // KCF longitudinal value in mm 
        public float dLWLVal = 0;
        public float dBMLVal = 0;

        public float _deltha = 29;//bobot total kapal saat ini
        // private float _BMl;//dari data hidrostatik sesuai dengan bobot kapal saat ini
        // private float _LWl;//dari data hidrostatik sesuai dengan bobot kapal saat ini
        public float _w;//beban muatan yang dipindahkan
        public float _l;//pergeseran muatan yang dipindahkan
        private float trimKapal;//dalam satuan panjang
        private float listKapal;//dalam satuan panjang
        private float _theta;// = -1.08f;//dalam satuan sudut

        private float Moment_Tray1 = 0, Moment_Tray2 = 0, Moment_Tray3 = 0, Moment_Tray4 = 0;
        private float GLoad_Tray1 = 0, GLoad_Tray2 = 0, GLoad_Tray3 = 0, GLoad_Tray4 = 0;
        private float GLoadTotalTransversal = 0;
        public float total_ARM = 0;


    
           
    //private float _theta = -1.08f;//dalam satuan sudut
        private int idx;
        private float LCGVal;
        private float TCGVal;
        private float CFVal;
        private float CBVal;
      
        private float _Gx;
        private float KG_real;



		// calculate load
		private float dx = 0.0f;
		private bool tabTrimHold = true;
		private bool tabBallast = false;
		private bool tabDraft = false;
		private bool tabAF = false;
		private bool tabLvAqua = false;
		private float tDraft;
		private int pil;
		//integrasi 

    #region Hydrostatic Data of General Cargo and Container

        float[] PosBay_Data = new float[8] { 589.1f, 469.1f, 255.4f, 135.4f, 4.4f, -115.6f, -323.9f, -443.9f};
        float[] PosRow_Data = new float[5] { 0.0f, 48.5f, -48.5f, 97.5f, -97.5f};

        // heel angle (deg),  GC and Container model scale 1:50, 20150824
        float[] heelData_GC = new float[8] { 0, 5, 10, 15, 20, 25, 30, 40 };

        // trim angle (deg),  GC and Container model scale 1:50, 20150824
        float[] trimData_GC = new float[5] { -10, -5, 0, 5, 10 };

        // displacement data, GC and Container model scale 1:50, 20150824
        float[] dispData_GC = new float[8] { 3.353f, 7.309f, 16.018f, 25.290f, 34.936f, 39.900f, 44.994f, 50.240f, };

        // draft data, GC and Container model scale 1:50, 20150824
        float[] draftData_GC = new float[8] { 10.0f, 20.0f, 40.0f, 60.0f, 80.0f, 90.0f, 100.0f, 110.0f };

        // LWL data, GC and container,20150826
        float[] dLWLData_GC = new float[7] { 1740.5f, 1759.06f, 1775.1f, 1779.71f, 1790f, 1870.89f, 1907.1f };

        //BML data, GC and container,20150826
        float[] dBMLData_GC = new float[7] { 301.179f, 317.861f, 328.75f, 328.882f, 329.24f, 329.459f, 329.606f };



        // new data, 20150822
        float KG_GC_REAL = 100.3f;  // mm from Keel (CATIA DATA, 20150821); 
        float LCG_GC = 958; // mm from AP (CATIA DATA, 20150821); 
        float KG_GC_ORCA3D = 63.652f;  // mm from Keel (vertical position of Zero point in ORCA3D, 20150821); 

        // lookup table data : knData(row, column), GC and Container model scale 1:50, 20150824
        // row   = dispData_GC
        // colum = heelData_GC
        float[,] knData_GC = new float[8, 8] {
                {0.00f,	59.00f,	72.42f,	77.54f,	82.69f,	87.29f,	91.43f,	98.70f},
                {0.00f,	38.49f,	65.35f,	78.76f,	86.17f,	90.60f,	94.66f,	103.18f},
                {0.00f,	22.63f,	43.88f,	62.99f,	75.44f,	85.96f,	95.33f,	113.32f},
                {0.00f,	17.00f,	33.57f,	49.60f,	64.86f,	77.64f,	87.91f,	91.30f},
                {0.00f,	14.52f,	28.80f,	43.00f,	57.17f,	69.94f,	72.94f,	67.25f},
                {0.00f,	13.87f,	27.52f,	41.14f,	53.99f,	61.98f,	64.97f,	56.11f},
                {0.00f,	13.46f,	26.72f,	39.58f,	50.96f,	55.08f,	57.68f,	47.59f},
                {0.00f,	13.24f,	26.27f,	38.33f,	45.06f,	49.71f,	50.06f,	41.78f}
        };


        // lookup table data : tcbData(row, column), GC and Container model scale 1:50, 20150824
        // row   = dispData_GC
        // colum = heelData_GC
        float[,] tcbData_GC = new float[8, 8] {
                {0.00f,	-58.87f,	-73.20f,	-80.24f,	-88.06f,	-95.91f,	-103.67f,	-118.43f},
                {0.00f,	-37.78f,	-64.57f,	-78.69f,	-87.56f,	-94.01f,	-100.37f,	-113.25f},
                {0.00f,	-20.95f,	-40.87f,	-58.99f,	-70.88f,	-80.98f,	-89.88f,	-105.94f},
                {0.00f,	-14.37f,	-28.61f,	-42.52f,	-55.78f,	-66.65f,	-75.00f,	-77.80f},
                {0.00f,	-10.96f,	-21.94f,	-33.01f,	-44.12f,	-53.86f,	-55.58f,	-40.74f},
                {0.00f,	-9.83f,	-19.71f,	-29.73f,	-39.09f,	-44.49f,	-45.18f,	-23.88f},
                {0.00f,	-8.95f,	-17.95f,	-26.76f,	-34.43f,	-35.68f,	-34.20f,	-8.90f},
                {0.00f,	-8.25f,	-16.54f,	-24.06f,	-27.10f,	-28.05f,	-21.91f,	4.58f}
        };

        // lookup table data : kbtData(row, column), KBT = KB transversal, GC and Container model scale 1:50, 20150824
        // row   = dispData_GC
        // colum = heelData_GC
        float[,] kbtData_GC = new float[8, 8] {
                {5.31f,	4.13f,	1.90f,	0.12f,	-0.19f,	0.86f,	3.31f,	12.44f},
                {10.66f,	9.70f,	10.12f,	10.64f,	11.40f,	12.75f,	15.46f,	25.59f},
                {21.38f,	20.23f,	20.90f,	23.24f,	25.91f,	29.83f,	35.10f,	50.54f},
                {32.03f,	30.80f,	31.11f,	33.02f,	36.57f,	41.05f,	46.33f,	56.23f},
                {42.67f,	41.41f,	41.47f,	43.01f,	46.15f,	50.56f,	53.33f,	57.03f},
                {48.02f,	46.75f,	46.73f,	48.11f,	50.80f,	53.62f,	56.81f,	59.40f},
                {53.42f,	52.14f,	52.07f,	53.23f,	55.53f,	57.37f,	60.15f,	63.79f},
                {58.89f,	57.61f,	57.49f,	58.50f,	59.65f,	62.04f,	63.45f,	70.43f}
        };


        // lookup table data : kmtData(row, column), KMT = KM transversal, GC and Container model scale 1:50, 20150824
        // row   = dispData_GC
        // colum = heelData_GC
        float[,] kmtData_GC = new float[8, 8] {
                {666.71f,	332.38f,	99.33f,	104.69f,	92.50f,	81.26f,	72.17f,	61.71f},
                {388.45f,	355.78f,	199.45f,	121.73f,	62.54f,	47.56f,	51.77f,	57.78f},
                {231.13f,	225.19f,	214.18f,	192.66f,	142.55f,	126.25f,	122.25f,	136.99f},
                {176.09f,	174.99f,	175.94f,	176.19f,	175.03f,	134.25f,	144.97f,	93.16f},
                {153.12f,	152.50f,	155.43f,	161.56f,	168.87f,	171.68f,	121.28f,	66.46f},
                {147.42f,	146.86f,	149.86f,	156.51f,	159.34f,	114.55f,	124.26f,	66.08f},
                {144.24f,	143.67f,	146.55f,	100.28f,	109.69f,	115.87f,	83.76f,	68.03f},
                {142.90f,	142.24f,	144.95f,	146.64f,	109.54f,	115.71f,	72.47f,	74.44f}
        };


        // lookup table data : lcbData(row, column), GC and Container model scale 1:50, 20150824
        // row = dispDataGZ_GC
        // colum = trimDataGZ_GC
        float[,] lcbData_GC = new float[8, 5] {
                {-592.203f,	-490.649f,	89.734f,	615.334f,	694.04f},
                {-558.946f,	-410.785f,	82.894f,	533.537f,	634.19f},
                {-516.271f,	-319.875f,	74.508f,	424.379f,	557.63f},
                {-477.622f,	-263.633f,	68.212f,	347.266f,	503.597f},
                {-434.031f,	-222.462f,	62.674f,	292.968f,	450.177f},
                {-407.228f,	-206.764f,	59.749f,	272.249f,	412.013f},
                {-375.351f,	-193.562f,	56.069f,	254.996f,	366.289f},
                {-336.158f,	-182.288f,	51.446f,	238.136f,	319.104f}
        };

        // lookup table data : kblData(row, column), kbl = KB longitudinal, GC and Container model scale 1:50, 20150824
        // row = dispData_GC
        // colum = trimData_GC
        float[,] kblData_GC = new float[8, 5] {
                {32.79f,	19.79f,	5.27f,	18.00f,	27.86f},
                {45.48f,	26.29f,	10.58f,	24.61f,	37.25f},
                {62.06f,	37.26f,	21.22f,	34.76f,	51.45f},
                {73.56f,	46.73f,	31.80f,	43.46f,	63.21f},
                {81.83f,	55.44f,	42.36f,	52.25f,	71.99f},
                {84.68f,	59.80f,	47.67f,	56.83f,	73.98f},
                {86.62f,	64.26f,	53.03f,	61.59f,	74.85f},
                {87.46f,	68.85f,	58.46f,	66.36f,	75.81f}
        };

        // lookup table data : kmlData(row, column), kml = KM longitudinal, GC and Container model scale 1:50, 20150824
        // row = dispData_GC
        // colum = trimData_GC
        float[,] kmlData_GC = new float[8, 5] {
                {1127.63f,	1714.27f,	16975.04f,	1444.91f,	637.03f},
                {1507.41f,	2122.98f,	9196.21f,	1837.70f,	832.15f},
                {1625.61f,	3295.60f,	4972.89f,	2454.67f,	1086.31f},
                {1663.21f,	3734.44f,	3509.91f,	2617.16f,	1331.76f},
                {1395.24f,	3608.79f,	2808.06f,	2508.15f,	1031.16f},
                {1221.57f,	3331.27f,	2623.27f,	2395.84f,	574.13f},
                {970.43f,	3050.75f,	2539.94f,	2278.77f,	451.92f},
                {647.59f,	2795.74f,	2487.71f,	1905.10f,	374.82f}
        };

        // lookup table data : lcfData(row, column), lcf = CF longitudinal, Crude Oil Tanker
        // row = dispData_GC
        // colum = trimData_GC
        float[,] lcfData_GC = new float[8, 5] {
            {-548.01f,	-396.60f,	81.71f,	522.25f,	627.26f},
            {-513.77f,	-298.84f,	73.37f,	414.73f,	547.48f},
            {-447.01f,	-200.29f,	62.15f,	262.83f,	447.71f},
            {-374.73f,	-136.04f,	52.82f,	175.69f,	376.68f},
            {-254.48f,	-100.06f,	42.94f,	131.53f,	213.62f},
            {-178.55f,	-92.94f,	34.38f,	122.57f,	62.82f},
            {-68.98f,	-87.66f,	19.78f,	117.67f,	-38.73f},
            {76.35f,	-83.73f,	4.01f,	65.66f,	-132.21f}
        };

        // lookup table data : kcfData(row, column), kcf = KF longitudinal, Crude Oil Tanker
        // row = dispData_GC
        // colum = trimData_GC
        float[,] kcfData_GC = new float[8, 5] {
            {46.45f,	    26.31f,	10.00f,	24.79f,	38.00f},
            {64.08f,	    36.78f,	20.00f,	35.04f,	51.68f},
            {85.71f,	    55.17f,	40.00f,	50.69f,	73.91f},
            {100.39f,	70.60f,	60.00f,	66.55f,	92.57f},
            {104.64f,	86.24f,	80.00f,	84.22f,	92.40f},
            {104.16f,	94.80f,	90.00f,	93.91f,	82.14f},
            {98.95f,	    103.62f,	100.00f,	103.92f,	82.58f},
            {89.56f,	    112.74f,	110.00f,	110.30f,	85.74f}
        };


        #endregion

    #region Lookup table data example

        // input data
		// row searching data : xData
		float[] xData = new float[5] { 1, 2, 3, 4, 5 };
		// column searching data : yData
		float[] yData = new float[4] { 2, 4, 6, 8 };
		// lookup table data : zData(row, column)
		float[,] zData = new float[5, 4]{
                                {4,	6,	8,	10}, 
                                { 5, 7,	9,	11}, 
                                { 8, 6,	4,	 2}, 
                                {10, 9,	8,	 7},
                                { 9, 8,	4,	 6}
        };
		// row searching data : thetaData
		float[] thetaData = new float[] { -5, -3, -1, 0, 1, 3, 5 };
		// column searching data : phiData
		float[] phiData = new float[] { -4, -2, 0, 2, 4 };
		// lookup table data : ycgData(row, column)
		float[,] ycgData = new float[,]{
                                {7,	5,	3,	-5,	-7}, 
                                {6,	4,	2,	-4,	-6}, 
                                {3,	2,	1,	-2,	-3}, 
                                {2,	1,	0,	-1,	-2},
                                {3,	2,	1,	-2,	-3},
                                {6,	4,	2,	-4,	-6},
                                {7,	5,	3,	-5,	-7}
        };

    #endregion

    #region Interpolation algorithm for lookup table 2D

		// global variables
		int N = 0; // number of row
		int M = 0; // number of column

		int i = 0;
		int j = 0;
		float zA = 0.0f;
		float zB = 0.0f;
		float zC = 0.0f;
		float zD = 0.0f;

		// float dx = 0.0f;
		float dy = 0.0f;
		float delx = 0.0f;
		float dely = 0.0f;

		private float Interpolate2D (float xs, float ys, float[] x, float[] y, float[,] z)
		{
				N = x.Length;
				M = y.Length;
				int k = 0;
				float zs = 0;

				// first check for input x
				if (xs < x [0]) {  // case 0
						i = 0;
				} else if (xs > x [N - 1]) { // case 1
						i = N - 2;
				} else { // case 2
						for (k = 0; k < N - 1; k++) {
								if (xs < x [k]) {
										break;
								}
						}
						i = k - 1;
				}

				// first check for input y
				if (ys < y [0]) {  // case 0
						j = 0;
				} else if (ys > y [M - 1]) { // case 1
						j = M - 2;
				} else { // case 2
						for (k = 0; k < M - 1; k++) {
								if (ys < y [k]) {
										break;
								}
						}
						j = k - 1;
				}

				zA = z [i, j];
				zB = z [i, j + 1];
				zC = z [i + 1, j + 1];
				zD = z [i + 1, j];

				dx = xs - x [i];
				dy = ys - y [j];
				delx = x [i + 1] - x [i];
				dely = y [j + 1] - y [j];

				zs = zA + dy / dely * (zB - zA) + dx / delx * (zD - zA) + dx / delx * dy / dely * (zA + zC - zB - zD);

				return zs;
		}

    #endregion

    #region Interpolation algorithm for lookup table 1D

		private float Interpolate1D (float xs, float[] x, float[] z)
		{
				N = x.Length;
				int k = 0;
				float zs = 0;

				// first check for input x
				if (xs < x [0]) {  // case 0
						i = 0;
				} else if (xs > x [N - 1]) { // case 1
						i = N - 2;
				} else { // case 2
						for (k = 0; k < N - 1; k++) {
								if (xs < x [k]) {
										break;
								}
						}
						i = k - 1;
				}

				zA = z [i];
				zB = z [i + 1];

				dx = xs - x [i];
				delx = x [i + 1] - x [i];

				zs = zA + dx / delx * (zB - zA);

				return zs;
		}

		// tutorial in array c#
		// http://msdn.microsoft.com/en-us/library/aa288453%28v=vs.71%29.aspx

    #endregion

    #region Graph algorithm

		// point float value
		struct pointd
		{
				public float x, y;
		}

		pointd[] shippoints = new pointd[13];
		pointd[] shippoints_init = new pointd[13];
		pointd[] shippoints_GC = new pointd[13] { 
            new pointd{x = -165.37f,	y = 145.66f},
            new pointd{x = -165.37f,	y = -32.84f},
            new pointd{x = -161.61f,	y = -44.57f},
            new pointd{x = -157.75f,	y = -50.84f},
            new pointd{x = -149.56f,	y = -57.59f},
            new pointd{x = -136.87f,	y = -62.64f},
            new pointd{x =       0.0f,	y = -62.64f},
            new pointd{x =  136.87f,	y = -62.64f},
            new pointd{x =  149.56f,	y = -57.59f},
            new pointd{x =  157.75f,	y = -50.84f},
            new pointd{x =  161.61f,	y = -44.57f},
            new pointd{x =  165.37f,	y = -32.84f},
            new pointd{x =  165.37f,	y = 145.66f},
        };

		private void rotate_point (ref float px, ref float py, float cx, float cy, float angle_deg)
		{
				float s = Mathf.Sin (angle_deg * Mathf.PI / 180);
				float c = Mathf.Cos (angle_deg * Mathf.PI / 180);

				// translate point back to origin:
				px -= cx;
				py -= cy;

				// rotate point
				float xnew = px * c - py * s;
				float ynew = px * s + py * c;

				// translate point back:
				px = xnew + cx;
				py = ynew + cy;
		}
  

    #endregion

    #region Curve Longitudinal Band,Load,Shear

		pointd[] shippointslon = new pointd[21]; // longitudinal hull coordinate
		pointd[] shippointslon_init = new pointd[21];
		pointd[] shippointslon_GC = new pointd[21] { 
            new pointd{x = -958.0f,	y = 207.3f}, // point 0
            new pointd{x = -941.5f,	y = 109.1f}, // point 1
            new pointd{x = -847.7f,	y =  87.3f}, // point 2
            new pointd{x = -838.5f,	y =  78.2f}, // point 3
            new pointd{x = -842.2f,	y =  45.5f}, // point 4
            new pointd{x = -834.8f,	y =  21.8f}, // point 5
            new pointd{x = -798.0f,	y =   0.0f}, // point 6
            new pointd{x =    0.0f,	y =   0.0f}, // point 7
            new pointd{x =  132.4f,	y =   0.0f}, // point 8
            new pointd{x =  327.3f,	y =   0.0f}, // point 9
            new pointd{x =  595.8f,	y =   0.0f}, // point 10
            new pointd{x =  893.6f,	y =   0.0f}, // point 11 
            new pointd{x =  913.9f,	y =   9.1f}, // point 12
            new pointd{x =  932.3f,	y =  27.3f}, // point 13
            new pointd{x =  939.6f,	y =  45.5f}, // point 14
            new pointd{x = 1005.8f,	y = 207.3f}, // point 15
            new pointd{x =  772.3f,	y = 207.3f}, // point 16
            new pointd{x =  709.8f,	y = 154.6f}, // point 17
            new pointd{x = -487.3f,	y = 154.6f}, // point 18
            new pointd{x = -544.3f,	y = 207.3f}, // point 19
            new pointd{x = -958.0f,	y = 207.3f}, // point 20
        };

		// longitudinal position for strength curve calculation, Container Ship (CS)
		pointd[] lonpos_CS = new pointd[28] { 
            new pointd{x =    0.0f,	y = 0}, // point 0
            new pointd{x =  227.5f,	y = 0}, // point 1
            new pointd{x =  455.0f,	y = 0}, // point 2
            new pointd{x =  455.0f,	y = 0}, // point 3  --> compartment 4
            new pointd{x =  574.0f,	y = 0}, // point 4  --> compartment 4
            new pointd{x =  693.0f,	y = 0}, // point 5  --> compartment 4
            new pointd{x =  693.0f,	y = 0}, // point 6
            new pointd{x =  738.2f,	y = 0}, // point 7
            new pointd{x =  783.4f,	y = 0}, // point 8  
            new pointd{x =  783.4f,	y = 0}, // point 9  --> compartment 3
            new pointd{x =  902.4f,	y = 0}, // point 10 --> compartment 3
            new pointd{x = 1021.4f,	y = 0}, // point 11 --> compartment 3
            new pointd{x = 1021.4f,	y = 0}, // point 12 
            new pointd{x = 1027.9f,	y = 0}, // point 13
            new pointd{x = 1027.9f,	y = 0}, // point 14
            new pointd{x = 1034.4f,	y = 0}, // point 15
            new pointd{x = 1034.4f,	y = 0}, // point 16 --> compartment 2
            new pointd{x = 1153.4f,	y = 0}, // point 17 --> compartment 2
            new pointd{x = 1272.4f,	y = 0}, // point 18 --> compartment 2
            new pointd{x = 1272.4f,	y = 0}, // point 19 
            new pointd{x = 1320.2f,	y = 0}, // point 20
            new pointd{x = 1368.0f,	y = 0}, // point 21
            new pointd{x = 1368.0f,	y = 0}, // point 22 --> compartment 1
            new pointd{x = 1487.0f,	y = 0}, // point 23 --> compartment 1
            new pointd{x = 1606.0f,	y = 0}, // point 24 --> compartment 1 
            new pointd{x = 1606.0f,	y = 0}, // point 25 
            new pointd{x = 1783.0f,	y = 0}, // point 26
            new pointd{x = 1960.0f,	y = 0}, // point 27
        };
    #endregion

        private WMG_Series wPoint0, wPoint1, wPoint2, wPoint3, wPoint4, wPoint5
                               , wPoint6, wPoint7, wPoint8, wPoint9, wPoint10, wPoint11;

        private WMG_Series wPoint12, wPoint13, wPoint14, wPoint15, wPoint16, wPoint17, wPoint18, wPoint19, wPoint20;

        private WMG_Series wPoint21, wPoint22, wPoint23, wPoint24, wPoint25, wPoint26, wPoint27, wPoint28;

        private WMG_Series wLCB, wLCF, wMCTC, wKBt, wKMt, wCp, wCb, wDisp, wTPC;//20150909 for Hydrostatic Curve


        float[,] gzDataTable2D;   // GZ table, 2D look-up table 
        float[,] knDataTable2D;   // KN table, 2D look-up table 
        float[,] tcbDataTable2D;  // TCB table, transversal CB, 2D look-up table
        float[,] lcbDataTable2D;  // LCB table, longitudinal CB, 2D look-up table
        float[,] kbtDataTable2D;  // KBT table, transversal KB, 2D look-up table
        float[,] kblDataTable2D;  // KBL table, longitudinal KB, 2D look-up table
        float[,] kmtDataTable2D;  // KMT table, transversal KM, 2D look-up table
        float[,] kmlDataTable2D;  // KML table, longitudinal KM, 2D look-up table
        float[,] kcfDataTable2D;  // KCF table, longitudinal KF, 2D look-up table
        float[,] lcfDataTable2D;  // LCF table, longitudinal CF, 2D look-up table
        float[] draftDataTable1D; // draught (draft), 1D look-up table (1D Table = Vector)
        float[] heelDataTable1D;  // heel angle, 1D look-up table (1D Table = Vector)
        float[] dispDataTable1D;  // displacement, 1D look-up table (1D Table = Vector)
        float[] trimDataTable1D;  // trim angle, 1D look-up table (1D Table = Vector)
        float[] lwlDataTable1D;// LWL data
        float[] bmlDataTable1D;// BML data

        float[] bayDataTable1D;//data pos Gx
        float[] rowDataTable1D;//data pos Gy
        public float kgDataOrca3D; // KG Data at ORCA3D,  
        // kgDataOrca3D is vertical position of Zero Point at ORCA3D measured from Keel
        // this is the center point of rotation
        public float kgDataReal;   // KG Data real, the real G point of ship 

       
        void Awake()
        {

            wPoint0 = GameObject.Find("s0-Ship").GetComponent<WMG_Series>();
            wPoint1 = GameObject.Find("s1-WL").GetComponent<WMG_Series>();
            wPoint2 = GameObject.Find("s2-KM").GetComponent<WMG_Series>();
            wPoint3 = GameObject.Find("s3-MB_line").GetComponent<WMG_Series>();
            wPoint4 = GameObject.Find("s4-GZ_line").GetComponent<WMG_Series>();
            wPoint5 = GameObject.Find("s5-KN_line").GetComponent<WMG_Series>();
            wPoint6 = GameObject.Find("s6-G_point").GetComponent<WMG_Series>();
            wPoint7 = GameObject.Find("s7-B_point").GetComponent<WMG_Series>();
            wPoint8 = GameObject.Find("s8-M_point").GetComponent<WMG_Series>();
            wPoint9 = GameObject.Find("s9-Z_point").GetComponent<WMG_Series>();
            wPoint10 = GameObject.Find("s10-K_point").GetComponent<WMG_Series>();
            wPoint11 = GameObject.Find("s11-N_point").GetComponent<WMG_Series>();

            wPoint25 = GameObject.Find("s12-G0").GetComponent<WMG_Series>();
            wPoint26 = GameObject.Find("s13-Gm").GetComponent<WMG_Series>();

            wPoint12 = GameObject.Find("s0-Ship_L").GetComponent<WMG_Series>();
            wPoint13 = GameObject.Find("s1-WL_L").GetComponent<WMG_Series>();
            wPoint14 = GameObject.Find("s2-WL_L").GetComponent<WMG_Series>();
            wPoint15 = GameObject.Find("s3-KM_line_L").GetComponent<WMG_Series>();
            wPoint16 = GameObject.Find("s4-BM_line_L").GetComponent<WMG_Series>();
            wPoint17 = GameObject.Find("s5-G_point_L").GetComponent<WMG_Series>();
            wPoint18 = GameObject.Find("s6-B_point_L").GetComponent<WMG_Series>();
            wPoint19 = GameObject.Find("s7-M_point_L").GetComponent<WMG_Series>();
            wPoint20 = GameObject.Find("s8-COF_point_L").GetComponent<WMG_Series>();
            wPoint27 = GameObject.Find("s9-G0").GetComponent<WMG_Series>();
            wPoint28 = GameObject.Find("s10-Gm").GetComponent<WMG_Series>();

            wPoint21 = GameObject.Find("sLoad").GetComponent<WMG_Series>();
            wPoint22 = GameObject.Find("sShear").GetComponent<WMG_Series>();
            wPoint23 = GameObject.Find("sBend").GetComponent<WMG_Series>();
            wPoint24 = GameObject.Find("sShipForm").GetComponent<WMG_Series>();



            //InitHydrostaticCurve();

            InitShipDataS();

        }
    void Start()
    {
        data = GetComponent<UnitySerialPort>();
       // data = new UnitySerialPort();
        shipMode = GameObject.FindWithTag("lambung");
        //pointLCG.active = false;
        //pointCF.active =true;
        //pointCB.active = false;
        data = UnitySerialPort.Instance;


        sdhTaruh = false;


        xWL = new float[2];
        yWL = new float[2];

        editHodl1P = "halo";


        camChart.active = false;
        chart2d.active = false;
        Port.active = false;


        jLama = 0;
        jBaru = 0;

        jLama1 = 0;
        jLama2 = 0;
        jLama3 = 0;
        jLama4 = 0;



        sldList = 2.5f;
        sldTrim = 2.5f;

        Draft_1P = 2.0f;
        Draft_2P = 2.0f;
        //// Draft_3P = float.Parse(data.AIData[20]);

        Draft_1SB = 2.0f;
        Draft_2SB = 2.0f;
        //// Draft_3SB = float.Parse(data.AIData[23]);


        posYShipM = 1.6f;
        waterBallastF();


        DraftSim();

        //DraftSim();
        //CalculateTranverseHydrostatic();
        //CalculateStrengthCurve_CS();
        //CalculateLongHydrostatic();
        GLoadTotalTransversal = 0;
    }
		void Update ()
		{

		// DataAI();
		if (ModeMaterial == true)
		{
			modeTransparan();
		}
		else if (ModeMaterial == false)
		{
			modeNormal();
		}



	}
        private void Rumus()
        {
            
           // dispTotal = _deltha + BobotTotal/1000;//displacment total
            total_ARM = ForeP(AF2P) + AftP(AF1P) + AftP(AF1SB) + ForeSB(AF2SB);
 
        }

	public void ActiveObjLoad()
    {
		menuInput = !menuInput;

		

	}
	
		//--------------------------------------------------------------------------
#region CHART

        //void ChangePointHydrostaticCurve()
        //{

        //    wLCB.setPointValues(sLCB);
        //    wLCB.setPointValuesChanged(true);

        //    wLCF.setPointValues(sLCF);
        //    wLCF.setPointValuesChanged(true);

        //    wMCTC.setPointValues(sMCTC);
        //    wMCTC.setPointValuesChanged(true);

        //    wKBt.setPointValues(sKBt);
        //    wKBt.setPointValuesChanged(true);

        //    wKMt.setPointValues(sKMt);
        //    wKMt.setPointValuesChanged(true);

        //    wCp.setPointValues(sCp);
        //    wCp.setPointValuesChanged(true);

        //    wCb.setPointValues(sCb);
        //    wCb.setPointValuesChanged(true);

        //    wTPC.setPointValues(sTPC);
        //    wTPC.setPointValuesChanged(true);

        //    wDisp.setPointValues(sDisp);
        //    wDisp.setPointValuesChanged(true);


        //}

        //void ClearHydrostaticCurve()
        //{

        //    sLCB.Clear();
        //    sLCF.Clear();
        //    sMCTC.Clear();
        //    sKBt.Clear();
        //    sKMt.Clear();
        //    sCp.Clear();
        //    sCb.Clear();
        //    sDisp.Clear();
        //    sTPC.Clear();


        //}

        //void InitHydrostaticCurve()
        //{
        //    wLCB = GameObject.Find("sLCB").GetComponent<WMG_Series>();
        //    wLCF = GameObject.Find("sLCF").GetComponent<WMG_Series>();
        //    wMCTC = GameObject.Find("sMCTC").GetComponent<WMG_Series>();
        //    wKBt = GameObject.Find("sKBt").GetComponent<WMG_Series>();
        //    wKMt = GameObject.Find("sKMt").GetComponent<WMG_Series>();
        //    wCp = GameObject.Find("sCp").GetComponent<WMG_Series>();
        //    wCb = GameObject.Find("sCb").GetComponent<WMG_Series>();
        //    wDisp = GameObject.Find("sDisp").GetComponent<WMG_Series>();
        //    wTPC = GameObject.Find("sTPC").GetComponent<WMG_Series>();


        //}

        //public void DrawHydrostaticCurve()
        //{
        //    ChangePointHydrostaticCurve();
        //    ClearHydrostaticCurve();



        //    //crtHydrostaticCurve.Series.Add(lcb_series);
        //    //crtHydrostaticCurve.Series.Add(lcf_series);
        //    //crtHydrostaticCurve.Series.Add(mtc_series);
        //    //crtHydrostaticCurve.Series.Add(dsp_series);
        //    //crtHydrostaticCurve.Series.Add(tpc_series);
        //    //crtHydrostaticCurve.Series.Add(kbt_series);
        //    //crtHydrostaticCurve.Series.Add(kmt_series);
        //    //crtHydrostaticCurve.Series.Add(cob_series);
        //    //crtHydrostaticCurve.Series.Add(cop_series);

            

        //    // to show legend, use only 1 command line = Legends.Add(...)
        //    // but first state series name!
        //    //crtHydrostaticCurve.Legends.Clear();
        //    //crtHydrostaticCurve.Legends.Add(lcb_series.Name);
        //    //crtHydrostaticCurve.Legends[0].Docking = Docking.Right;

        //    for (int i = 0; i < dispDataTable1D.Length; i++)
        //    {
        //        //lcb_series.Points.AddXY(lcbDataTable2D[i, 2], draftDataTable1D[i]);
        //        //lcf_series.Points.AddXY(lcfDataTable2D[i, 2], draftDataTable1D[i]);
        //        //dsp_series.Points.AddXY(dispDataTable1D[i], draftDataTable1D[i]);
        //        //kbt_series.Points.AddXY(kbtDataTable2D[i, 0], draftDataTable1D[i]);
        //        //kmt_series.Points.AddXY(kmtDataTable2D[i, 0], draftDataTable1D[i]);
        //        //mtc_series.Points.AddXY(mttDataTable1D[i], draftDataTable1D[i]); // MTCT
        //        //tpc_series.Points.AddXY(wtiDataTable1D[i], draftDataTable1D[i]); // TPC
        //        //cob_series.Points.AddXY(cobDataTable1D[i], draftDataTable1D[i]); // Cb = Block Coefficient
        //        //cop_series.Points.AddXY(copDataTable1D[i], draftDataTable1D[i]); // Cp = Prismatic Coefficient

        //        sLCB.Add(new Vector2(lcbDataTable2D[i,2],draftDataTable1D[i]));
        //        sLCF.Add(new Vector2(lcfDataTable2D[i, 2], draftDataTable1D[i]));
        //        sDisp.Add(new Vector2(dispDataTable1D[i], draftDataTable1D[i]));
        //        sKBt.Add(new Vector2(kbtDataTable2D[i,0], draftDataTable1D[i]));
        //        sKMt.Add(new Vector2(kmtDataTable2D[i, 0], draftDataTable1D[i]));

        //    }
        //}


		void ClearPointT ()//clear point transversal
		{

				pointSeries0.Clear ();
				pointSeries1.Clear ();
				pointSeries2.Clear ();
				pointSeries3.Clear ();
				pointSeries4.Clear ();
				pointSeries5.Clear ();
				pointSeries6.Clear ();
				pointSeries7.Clear ();
				pointSeries8.Clear ();
				pointSeries9.Clear ();
				pointSeries10.Clear ();
				pointSeries11.Clear ();
                pointSeries25.Clear();
                pointSeries26.Clear();

		}

		void ClearPointL ()//clear point longitudinal
		{

				pointSeries12.Clear ();
				pointSeries13.Clear ();
				pointSeries14.Clear ();
				pointSeries15.Clear ();
				pointSeries16.Clear ();
				pointSeries17.Clear ();
				pointSeries18.Clear ();
				pointSeries19.Clear ();
				pointSeries20.Clear ();

                pointSeries27.Clear();
                pointSeries28.Clear();

		}

		void ClearPointS ()//clear point longitudinal
		{
				pointSeries21.Clear ();
				pointSeries22.Clear ();
				pointSeries23.Clear ();
				pointSeries24.Clear ();
		}

      

        public void CalculateTranverseHydrostatic()
        {
            ChangePointHydrostatic();
            Rumus();
			//posYShip=-tDraft - 10.0f;

            float temp_ycgTShip, temp_zcgTShip;
            float temp_ycgLShip, temp_zcgLShip;
		float temp_draft;

            if (menuInput == true)
            {
                tempDisp = dWeightTotalShip;
                _JumCon = iLoadCount;
                _BobotTotal = dWeightTotalLoad;
                TempList = _list;

                temp_yCG = yCGTotalLoad;
                temp_zCG = zCGTotalLoad;

                temp_ycgTShip = yCGTotalShip;
                temp_zcgTShip = zCGTotalShip;
				temp_draft=Interpolate1D(dDispVal, dispDataTable1D, draftDataTable1D);

               
               // TempTrim = _tTrim;
                //shipVessel.transform.localEulerAngles = new Vector3(TempList, 0, TempTrim);
            }
            else
            {
                tempDisp = _deltha + (F1 + F2 + F3 + F4) / 1000 + total_ARM;
                _JumCon = jCon1 + jCon2 + jCon3 + jCon4;
                _BobotTotal = (F1 + F2 + F3 + F4) / 1000;
                TempList = -Konv_Sudut(sldList);
				temp_draft=posYShip;


//			PosBebanTray1();
//			PosBebanTray2();
//			PosBebanTray3();
//			PosBebanTray4();
			
			VoltTotal = VoltPort1 + VoltPort2 + VoltPort3 + VoltPort4 +
                        VoltStar1 + VoltStar2 + VoltStar3 + VoltStar4;

                if (VoltTotal > 0)
                {

                    GLoadTotalTransversal = (Moment_Tray1 + Moment_Tray2 + Moment_Tray3 + Moment_Tray4) / VoltTotal;
                }
                else
                {
                    GLoadTotalTransversal = 0;
                }

                temp_yCG = GLoadTotalTransversal;
                temp_zCG = zCGTotalLoad;

                temp_ycgTShip = yCGTotalShip;
                temp_zcgTShip = kgDataReal;

                fromAI();
            }

          

            dDispVal = tempDisp;//total input dari slider
			dDraftVal = temp_draft;//Interpolate1D(dDispVal, dispDataTable1D, draftDataTable1D);
            dOutput1 = dDraftVal;

            dHeelVal = TempList;
          //  shipVessel.transform.localEulerAngles = new Vector3(dHeelVal, 0, 0);
           
            //dHeelVal = tempDheel;
            if (dHeelVal >= 0)
            {
                //dGZVal = Interpolate2D(dDispVal, dHeelVal, dispDataTable1D, heelDataTable1D, gzDataTable2D);
                dKNVal = Interpolate2D(dDispVal, dHeelVal, dispDataTable1D, heelDataTable1D, knDataTable2D);
                dTCBVal = Interpolate2D(dDispVal, dHeelVal, dispDataTable1D, heelDataTable1D, tcbDataTable2D);
            }
            else
            {
                //dGZVal = -1 * Interpolate2D(dDispVal, -dHeelVal, dispDataTable1D, heelDataTable1D, gzDataTable2D);
                dKNVal = -1 * Interpolate2D(dDispVal, -dHeelVal, dispDataTable1D, heelDataTable1D, knDataTable2D);
                dTCBVal = -1 * Interpolate2D(dDispVal, -dHeelVal, dispDataTable1D, heelDataTable1D, tcbDataTable2D);
            }

            dKBTVal = Interpolate2D(dDispVal, Mathf.Abs(dHeelVal), dispDataTable1D, heelDataTable1D, kbtDataTable2D);
            dKMTVal = Interpolate2D(dDispVal, Mathf.Abs(dHeelVal), dispDataTable1D, heelDataTable1D, kmtDataTable2D);

         

            ClearPointT();//clear point



            float cX = 0;
            float cY = kgDataOrca3D; // ini adalah titik yang tepat, ssw 20140823
            //float cY = dKMTVal;

            // define G point, in Ship coordinate
            float Gx = temp_ycgTShip;
            float Gy = temp_zcgTShip;

            // define K point, in Ship coordinate, point C as center of rotation, 20140819
            float Kx = 0;
            float Ky = 0;

            // define M point, in Ship coordinate, point C as center of rotation, 20140819
            float Mx = 0;
            float My = dKMTVal;

            // define B point, in Ship coordinate
            float Bx = dTCBVal;
            float By = dKBTVal;

            //// define Z Point, in Ship coordinate
            //float Zx = -dGZVal;
            //float Zy = Gy;

            // define N Point, in Ship coordinate
            float Nx = -dKNVal;
            float Ny = Ky;

            // define G0 point (G lightship) in Ship coordinate, 20150827
            float G0x = yCGLightShip;
            float G0y = zCGLightShip;

            // define Gm point (G total load) in Ship coordinate, 20150827
            Gmx = temp_yCG;//yCGTotalLoad;
            Gmy = temp_zCG;

            print("GmY : " + temp_yCG.ToString("F2"));

            // do rotational transformation, point C as center of rotation
            rotate_point(ref Gx, ref Gy, cX, cY, dHeelVal);
            rotate_point(ref Mx, ref My, cX, cY, dHeelVal);
            rotate_point(ref Bx, ref By, cX, cY, dHeelVal);
            rotate_point(ref Nx, ref Ny, cX, cY, dHeelVal);
            rotate_point(ref Kx, ref Ky, cX, cY, dHeelVal);

            rotate_point(ref G0x, ref G0y, cX, cY, dHeelVal); // 20150827
            rotate_point(ref Gmx, ref Gmy, cX, cY, dHeelVal); // 20150827


            xWL[0] = -300.0f;
            yWL[0] = 0.0f;

            xWL[1] = 300.0f;
            yWL[1] = 0.0f;


            //

           


            //rotate_point(ref Gx, ref Gy, cX, cY, Konv_Sudut(dHeel));
            //rotate_point(ref Kx, ref Ky, cX, cY, Konv_Sudut(dHeel));
            //rotate_point(ref Mx, ref My, cX, cY, Konv_Sudut(dHeel));
            //rotate_point(ref Bx, ref By, cX, cY, Konv_Sudut(dHeel));

            //// correct B, Z and M points (re-rotate M point)
            //// SSW, 20140823
            //Zx = (Zx + Bx) / 2;
            //Bx = Zx;
            //dGZVal = -Zx;
            //dTCBVal = Bx;
            //if (Mathf.Abs(Konv_Sudut(dHeel)) > 0.01f)
            //    dKMVal = kgData + dGZVal / Mathf.Sin(Konv_Sudut(dHeel) * Mathf.PI / 180);
            //Mx = 0;
            //My = dKMVal;
            //rotate_point(ref Mx, ref My, cX, cY, Konv_Sudut(dHeel));

            //// calculate and draw KN
            //float BM = My - By;
            //float KN = BM * Mathf.Tan(Konv_Sudut(dHeel) * Mathf.PI / 180);
            //float Nx = Bx;
            //float Ny = Ky;
            // calculate and draw GZ, calculate KN correction
            // note: if we calculate KN directly from knData,
            // we will get inconsisten position of KN, so we need to correct it
            // ssw, 20150824
            float BMx = Mx - Bx;
            float BMy = My - By;
            float GMy = My - Gy;
            float KMy = My - Ky;
            float Zx = 0;
            dGZVal = 0;
            if (BMx != 0)
            {
                Zx = Mx - GMy / BMy * BMx;
                dGZVal = Mathf.Sign(My - Gy) * Mathf.Abs(Zx - Gx);
                Nx = Mx - KMy / BMy * BMx;
            }
            float Zy = Gy;
            Ny = Ky;
            if (dGZVal < 0)
            {
               // txbGZInfo.ForeColor = Color.Red;
                //txbGZInfo.Text = "Maximum Heel Angle !!!";
            }
            else
            {
                //txbGZInfo.ForeColor = Color.Green;
                //txbGZInfo.Text = "Heel Angle is Allowed";
            }


            shippoints = (pointd[])shippoints_init.Clone();
            for (int i = 0; i < shippoints.Length; i++)
            {
                rotate_point(ref shippoints[i].x, ref shippoints[i].y, cX, cY, dHeelVal);
                pointSeries0.Add(new Vector2(shippoints[i].x, shippoints[i].y));
            }

            //draw water lain
            for (int i = 0; i < 2; i++)
            {
                pointSeries1.Add(new Vector2(xWL[i], dDraftVal));
            }

            //draw KM line
            pointSeries2.Add(new Vector2(Mx, My)); // series 2, M point
            pointSeries2.Add(new Vector2(Kx, Ky)); // series 2, K point

            //draw BM line
            pointSeries3.Add(new Vector2(Mx, My)); // series 3, M point
            pointSeries3.Add(new Vector2(Bx, By)); // series 3, B point

            // draw GZ line
            pointSeries4.Add(new Vector2(Gx, Gy)); // series 4, G point
            pointSeries4.Add(new Vector2(Zx, Zy)); // series 4, Z point

            // draw KN line
            pointSeries5.Add(new Vector2(Kx, Ky)); // series 5, K point
            pointSeries5.Add(new Vector2(Nx, Ny)); // series 5, N point

            // Draw G, B, M, Z point
            pointSeries6.Add(new Vector2(Gx, Gy));
            pointSeries7.Add(new Vector2(Bx, By));
            pointSeries8.Add(new Vector2(Mx, My));  // series 8, M point
            pointSeries9.Add(new Vector2(Zx, Zy));  // series 9, Z point
            pointSeries10.Add(new Vector2(Kx, Ky)); // series 10, K point
            pointSeries11.Add(new Vector2(Nx, Ny)); // series 11, N poi

            pointSeries25.Add(new Vector2(G0x, G0y)); //G0
            pointSeries26.Add(new Vector2(Gmx, Gmy)); // Gm


            //txbGZValue.Text = dGZVal.ToString("F2");
            //txbKBValue.Text = dKBVal.ToString("F2");
            //txbKMValue.Text = dKMVal.ToString("F2");
            //txbDraftValue.Text = dOutput1.ToString("F2");
            //txbKGValue.Text = kgData.ToString("F2");
            //txbTCBValue.Text = dTCBVal.ToString("F2");




        }// for sensor

        public void CalculateLongHydrostatic()
        {
		float temp_draft;
            ChangePointLong();
            Rumus();



            if (menuInput == true)
            {
                tempDisp = dWeightTotalShip;
                _JumCon = iLoadCount;
                _BobotTotal = dWeightTotalLoad;
               // TempList = _list;
                TempTrim = _tTrim;
				temp_draft=Interpolate1D(dDispVal, dispDataTable1D, draftDataTable1D);
               // shipVessel.transform.localEulerAngles = new Vector3(-TempList, 0, TempTrim);
            }
            else
            {
                tempDisp = _deltha + (F1 + F2 + F3 + F4) / 1000 + total_ARM;
                _JumCon = jCon1 + jCon2 + jCon3 + jCon4;
                _BobotTotal = (F1 + F2 + F3 + F4) / 1000;
              //  TempList = Konv_Sudut(sldList);
                TempTrim = Konv_Sudut(sldTrim);
               fromAI();
			temp_draft=posYShip;
            }

            //if (data.SerialPort.IsOpen == true)
            //{
            //    tempDisp = dispTotal;
            //}
            //else
            //{
            //    tempDisp = 0;
            //}

            dDispVal = tempDisp;
            dDraftVal = Interpolate1D(dDispVal, dispDataTable1D, draftDataTable1D);
            dOutput1 = dDraftVal;


            dPitchVal = TempTrim;
            dTrimVal = -dPitchVal;

           // shipVessel.transform.localEulerAngles = new Vector3(0, 0, dPitchVal);

            dKBLVal = Interpolate2D(dDispVal, dTrimVal, dispDataTable1D, trimDataTable1D, kblDataTable2D);
            dKMLVal = Interpolate2D(dDispVal, dTrimVal, dispDataTable1D, trimDataTable1D, kmlDataTable2D);
            dLCBVal = Interpolate2D(dDispVal, dTrimVal, dispDataTable1D, trimDataTable1D, lcbDataTable2D);

            dLCFVal = Interpolate2D(dDispVal, dTrimVal, dispDataTable1D, trimDataTable1D, lcfDataTable2D);
            dKCFVal = Interpolate2D(dDispVal, dTrimVal, dispDataTable1D, trimDataTable1D, kcfDataTable2D);

            dLWLVal = Interpolate1D(dDispVal, dispDataTable1D, lwlDataTable1D);
            dBMLVal = Interpolate1D(dDispVal, dispDataTable1D, bmlDataTable1D);



            ClearPointL();

            // Set reference points: center of rotation
            //double cX = dLCFVal;
            //double cY = dKCFVal; // ini adalah titik yang tepat, ssw 20140823
            float cX = 0;
            float cY = kgDataOrca3D; // ini adalah titik yang tepat, ssw 20140823

            // set G point, in Ship coordinate
            // set G point (G total ship), in Ship coordinate
            float Gx = xCGTotalShip;
            float Gy = zCGTotalShip;

            // set K point, in Ship coordinate, 
            float Kx = 0;
            float Ky = 0;

            // set M point, in Ship coordinate, 
            float Mx = dLCFVal;
            float My = dKMLVal;

            // set B point, in Ship coordinate
            float Bx = dLCBVal;
            float By = dKBLVal;

            // set COF point, in Ship coordinate
            float COFx = dLCFVal;
            float COFy = dKCFVal;

            xWL[0] = -1000.0f;
            yWL[0] = 0.0f;

            xWL[1] = 1100.0f;
            yWL[1] = 0.0f;

            // set rotable WL point, in Ship coordinate
            float WL1x = 0.9f * xWL[0];
            float WL2x = 0.9f * xWL[1];

            float WL1y = dDraftVal;
            float WL2y = dDraftVal;


            // draw rotated longitudinal plane of the ship
            shippointslon = (pointd[])shippointslon_init.Clone();
            for (int i = 0; i < shippointslon.Length; i++)
            {
                rotate_point(ref shippointslon[i].x, ref shippointslon[i].y, 0, dDraftVal, dPitchVal);
                pointSeries12.Add(new Vector2(shippointslon[i].x, shippointslon[i].y));
            }

            // define G0 point (G lightship) in Ship coordinate, 20150827
            float G0x = xCGLightShip;
            float G0y = zCGLightShip;

            // define Gm point (G total load) in Ship coordinate, 20150827
            float Gmx = xCGTotalLoad;
            float Gmy = zCGTotalLoad;

            rotate_point(ref Gx, ref Gy, cX, cY, dPitchVal);
            rotate_point(ref Kx, ref Ky, cX, cY, dPitchVal);
            rotate_point(ref Mx, ref My, cX, cY, dPitchVal);
            rotate_point(ref Bx, ref By, cX, cY, dPitchVal);
            rotate_point(ref COFx, ref COFy, cX, cY, dPitchVal);
            rotate_point(ref WL1x, ref WL1y, cX, cY, dPitchVal);
            rotate_point(ref WL2x, ref WL2y, cX, cY, dPitchVal);

            rotate_point(ref G0x, ref G0y, cX, cY, dPitchVal);
            rotate_point(ref Gmx, ref Gmy, cX, cY, dPitchVal);



            // draw static WL (waterline)
            for (int i = 0; i < 2; i++)
            {
                pointSeries13.Add(new Vector2(xWL[i], dDraftVal));
            }

            // draw rotated WL line
            pointSeries14.Add(new Vector2(WL1x, WL1y));
            pointSeries14.Add(new Vector2(WL2x, WL2y));

            // draw KML line
            pointSeries15.Add(new Vector2(Mx, My)); // series 3, M point
            pointSeries15.Add(new Vector2(Kx, Ky)); // series 3, K point

            // draw BM line
            pointSeries16.Add(new Vector2(Mx, My)); // series 4, M point
            pointSeries16.Add(new Vector2(Bx, By)); // series 4, B point



            // Draw G, B, M, COF point
            pointSeries17.Add(new Vector2(Gx, Gy));
            pointSeries18.Add(new Vector2(Bx, By));
            pointSeries19.Add(new Vector2(Mx, My));
            pointSeries20.Add(new Vector2(COFx, COFy));

            pointSeries27.Add(new Vector2(G0x, G0y));
            pointSeries28.Add(new Vector2(Gmx, Gmy));

            // Show values in textbox
            //txbKMLValue.Text = dLonKMVal.ToString("F2");
            //txbLCBValue.Text = dLCBVal.ToString("F2");
            //txbLCFValue.Text = dLCFVal.ToString("F2");

        }//for sensor

        private void CalculateStrengthCurve_CS() // 20140926, 20141003, Container Ship Model
        {

            float tempDisp;
            float tempJumCon;
          




            tempDisp = dispTotal;
           
            



          


            // Container Ship Model
            // Note SSW, 20141003 : 
            // Container Hull = General Cargo Hull, BUT DIFFER IN cargo compartment

            float sb1 = 0.9386f; // m
            float sb2 = 1.0214f;
            float sf1 = 0.2380f;
            float sf2 = 0.2380f;
            float sf3 = 0.2380f;
            float sf4 = 0.2380f;
            float lb1 = 0.4693f;
            float lb2 = 0.5107f;
            float lf1 = 0.4656f;
            float lf2 = 0.1320f;
            float lf3 = 0.1190f;
            float lf4 = 0.4474f;

            if (menuInput == true)
            {
                tempDisp = dispTotal;
                _JumCon = jumCon;
                _BobotTotal = BobotTotal / 1000;

                F1 = iBay1Row0 + iBay1Row1 + iBay1Row2 +
                    iBay3Row0 + iBay3Row1 + iBay3Row2 + iBay3Row3 + iBay5Row4 / 10000;

                F2 = iBay5Row0 + iBay5Row1 + iBay5Row2 + iBay5Row3 + iBay5Row4 +
                    iBay7Row0 + iBay7Row1 + iBay7Row2 + iBay7Row3 + iBay7Row4 / 10000;

                F3 = iBay9Row0 + iBay9Row1 + iBay9Row2 + iBay9Row3 + iBay9Row4 +
                     iBay11Row0 + iBay11Row1 + iBay11Row2 + iBay11Row3 + iBay11Row4 / 10000;

                F4 = iBay13Row0 + iBay13Row1 + iBay13Row2 + iBay13Row3 + iBay13Row4 +
                     iBay15Row0 + iBay15Row1 + iBay15Row2 + iBay15Row3 + iBay15Row4 / 10000;

            }
            else
            {
                tempDisp = 29 + (F1 + F2 + F3 + F4) / 1000;
                _JumCon = jCon1 + jCon2 + jCon3 + jCon4;
                _BobotTotal = (F1 + F2 + F3 + F4) / 1000;
                fromAI();
                F1 = Hold1_1P + Hold1_1SB + Hold1_1P + Hold1_2SB;
                F2 = Hold2_1P + Hold2_1SB + Hold2_1P + Hold2_2SB;
                F3 = Hold3_1P + Hold3_1SB + Hold3_1P + Hold3_2SB;
                F4 = Hold4_1P + Hold4_1SB + Hold4_1P + Hold4_2SB;
            }

            // load
            //float F1 = 4.00; // kgf
            //float F2 = 3.20; // kgf
            //float F3 = 4.32; // kgf
            //float F4 = 2.72; // kgf
            //float F1 = (float)(scbInputF1.Maximum - scbInputF1.Value) / 1000; // kgf
            //float F2 = (float)(scbInputF2.Maximum - scbInputF2.Value) / 1000; // kgf
            //float F3 = (float)(scbInputF3.Maximum - scbInputF3.Value) / 1000; // kgf
            //float F4 = (float)(scbInputF4.Maximum - scbInputF4.Value) / 1000; // kgf
            


            Ftot = F1 + F2 + F3 + F4;
            float B1 = (Ftot * lb2 + (F1 * lf1 + F2 * lf2 - F3 * lf3 - F4 * lf4)) / (lb1 + lb2);
            float B2 = (Ftot * lb1 - (F1 * lf1 + F2 * lf2 - F3 * lf3 - F4 * lf4)) / (lb1 + lb2);

            //float B1 = (totalH * lb2 + (5 * lf1 + 5 * lf2 - 5 * lf3 - 5 * lf4)) / (lb1 + lb2);
            //float B2 = (totalH * lb1 - (5 * lf1 + 5 * lf2 - 5 * lf3 - 5 * lf4)) / (lb1 + lb2); 

            float sigmaB1 = B1 / sb1;
            float sigmaB2 = B2 / sb2;
            float sigmaF1 = F1 / sf1;
            float sigmaF2 = F2 / sf2;
            float sigmaF3 = F3 / sf3;
            float sigmaF4 = F4 / sf4;

            ChangePointCurve();
            ClearPointS();

            float x;
            float dx;
            float sigma;
            float shearforce = 0.0f;
            float bdgmoment = 0.0f;


            // Longitudinal data in chart
            // series[0]  = hull ship, longitudinal
            // series[1]  = load line 
            // series[2]  = shear force line 
            // series[3]  = bending moment line 

            // clear all series, except series number 0 (hull ship form)
            //for (int i = 1; i < crtStrengthCurve.Series.Count; i++)
            //{
            //    crtStrengthCurve.Series[i].Points.Clear();
            //}


            shippointslon = (pointd[])shippointslon_init.Clone();
            for (int i = 0; i < shippointslon.Length; i++)
            {
                //rotate_point(ref shippointslon[i].x, ref shippointslon[i].y, 0, dDraftVal, Konv_Sudut(sldTrim));
                pointSeries24.Add(new Vector2(shippointslon[i].x, shippointslon[i].y));
            }

            int iRef = 0;
            for (int i = 0; i < lonpos_CS.Length; i++)
            {
                if (i < 3)
                {
                    iRef = 0;
                    sigma = sigmaB2;
                }
                else if (i < 6)
                { // compartment 4
                    iRef = 2;
                    sigma = sigmaB2 - sigmaF4;
                }
                else if (i < 9)
                {
                    iRef = 5;
                    sigma = sigmaB2;
                }
                else if (i < 12)
                { // compartment 3
                    iRef = 8;
                    sigma = sigmaB2 - sigmaF3;
                }
                else if (i < 14)
                {
                    iRef = 11;
                    sigma = sigmaB2;
                }
                else if (i < 16)
                {
                    iRef = 13;
                    sigma = sigmaB1;
                }
                else if (i < 19)
                { // compartment 2
                    iRef = 15;
                    sigma = sigmaB1 - sigmaF2;
                }
                else if (i < 22)
                {
                    iRef = 18;
                    sigma = sigmaB1;
                }
                else if (i < 25)
                { // compartment 1
                    iRef = 21;
                    sigma = sigmaB1 - sigmaF1;
                }
                else
                {
                    iRef = 24;
                    sigma = sigmaB1;
                }

                dx = (lonpos_CS[i].x - lonpos_CS[iRef].x) * 0.001f; // in meter
                if (i > 0)
                {
                    //shearforce = shearline_series.Points[iRef].YValues[0] / scale_sf + sigma * dx;
                    shearforce = pointSeries22[iRef].y / scale_sf + sigma * dx;
                    //bdgmoment = bmomentline_series.Points[iRef].YValues[0] / scale_bm + 0.5f * (shearline_series.Points[iRef].YValues[0] / scale_sf + shearforce) * dx;
                    bdgmoment = pointSeries23[iRef].y / scale_bm + 0.5f * (pointSeries22[iRef].y / scale_sf + shearforce) * dx;
                }
                x = lonpos_CS[i].x - LCG_GC; // in mm
                pointSeries21.Add(new Vector2(x, sigma * scale_ld));//load
                pointSeries22.Add(new Vector2(x, shearforce * scale_sf));//shearline_series
                pointSeries23.Add(new Vector2(x, bdgmoment * scale_bm));//bmomentLine_series
                print(" data ke-" + i + " " + bdgmoment * scale_bm);
            }

            //// searching for zero shear force
            //float sfa, sfb, xa, xb;
            //WMG_Series zerosf_pos = new WMG_Series();
            //WMG_Series ld_zerosf = new WMG_Series(); // load distribution (sigma) at zero sf
            //WMG_Series bm_zerosf = new WMG_Series(); // bending moment at zero sf
            //int k = 0;
            //while (k < shearline_series.pointValues.Count - 1)
            //{
            //    //sfa = shearline_series.pointValues[k].y;
            //    sfa = pointSeries22[k].y;
            //    //sfb = shearline_series.pointValues[k + 1].y;
            //    sfb = pointSeries22[k + 1].y;

            //    if (sfa * sfb < 0) // curve crossing x-axis, so there must be zero shear force
            //    {
            //        //xa = shearline_series.pointValues[k].x; // in mm
            //        xa = pointSeries22[k].x;
            //        xb = pointSeries22[k + 1].x; // in mm
            //        x = (xa - sfa / sfb * xb) / (1 - sfa / sfb);
            //        dx = (x - xa) * 0.001f; // in meter
            //        //sigma = (loadline_series.Points[i].YValues[0] + loadline_series.Points[i + 1].YValues[0]) / 2;
            //        sigma = pointSeries21[k].y / scale_ld;
            //        shearforce = 0;
            //        bdgmoment = 0;// bmomentLine_series.pointValues[k] / scale_bm + 0.5f * (shearline_series.pointValues[k].y / scale_sf) * dx;
            //        //zerosf_pos.Points.AddXY(i, x); //
            //        //ld_zerosf.Points.AddXY(i, sigma);
            //        //bm_zerosf.Points.AddXY(i, bdgmoment);
            //        pointSeries21.Insert(new Vector2(k + 1, x, sigma * scale_ld));
            //        pointSeries22.Insert(new Vector2(k + 1, x, shearforce * scale_sf));
            //        pointSeries23.Insert(new Vector2(k + 1, x, bdgmoment * scale_bm));



            //        //pointSeries21.Add(new Vector2(x, sigma * scale_ld));//load
            //        //pointSeries22.Add(new Vector2(x, shearforce * scale_sf));//shearline_series
            //        //pointSeries23.Add(new Vector2(x, bdgmoment * scale_bm));//bmomentLine_series
            //    }
            //    k += 1;
            //} // end of while

            // show in listview
            //lsvStrengthCurve.Items.Clear();
            //ListViewItem lvi = null;
            //for (int i = 0; i < loadline_series.Points.Count; i++)
            //{
            //    sigma = loadline_series.Points[i].YValues[0] / scale_ld;
            //    shearforce = shearline_series.Points[i].YValues[0] / scale_sf;
            //    bdgmoment = bmomentline_series.Points[i].YValues[0] / scale_bm;
            //    lvi = new ListViewItem(loadline_series.Points[i].XValue.ToString("F2"));
            //    lvi.SubItems.Add(sigma.ToString("F3")); // load
            //    lvi.SubItems.Add(shearforce.ToString("F3")); // shear force
            //    lvi.SubItems.Add(bdgmoment.ToString("F3")); // bending moment
            //    lsvStrengthCurve.Items.Add(lvi);
            //}

        } //for sensor

		void InitShipDataS ()
		{

            knDataTable2D = (float[,])knData_GC.Clone();
            tcbDataTable2D = (float[,])tcbData_GC.Clone();
            kbtDataTable2D = (float[,])kbtData_GC.Clone();
            kmtDataTable2D = (float[,])kmtData_GC.Clone();
            lcbDataTable2D = (float[,])lcbData_GC.Clone();
            kblDataTable2D = (float[,])kblData_GC.Clone();
            kmlDataTable2D = (float[,])kmlData_GC.Clone();
            lcfDataTable2D = (float[,])lcfData_GC.Clone();
            kcfDataTable2D = (float[,])kcfData_GC.Clone();
            draftDataTable1D = (float[])draftData_GC.Clone();
            heelDataTable1D = (float[])heelData_GC.Clone();
            dispDataTable1D = (float[])dispData_GC.Clone();
            trimDataTable1D = (float[])trimData_GC.Clone();
            lwlDataTable1D = (float[])dLWLData_GC.Clone();
            bmlDataTable1D = (float[])dBMLData_GC.Clone();

          



            kgDataOrca3D = KG_GC_ORCA3D;
            kgDataReal = KG_GC_REAL;

            // initialize amidship points, then translate each point 
            shippoints_init = (pointd[])shippoints_GC.Clone();
            for (int i = 0; i < shippoints_init.Length; i++)
            {
                shippoints_init[i].y += kgDataOrca3D;
            }
            // initialize ship longitudinal plane, 20141003 
            shippointslon_init = (pointd[])shippointslon_GC.Clone();

            // Loading and CG calculation, Container
            iLoadDataTable2D = (int[,])iLoadDataTable2D.Clone();
            xLoadDataTable2D = (float[,])xLoadDataTable2D.Clone();
            yLoadDataTable2D = (float[,])yLoadDataTable2D.Clone();
            zLoadDataTable2D = (float[,])zLoadDataTable2D.Clone();

            dWeightLightShip = dWeightLightShip;
            dWeightTotalLoad = dWeightTotalLoad;
            dWeightTotalShip = dWeightTotalShip;

            //iRowPosition = iRowPosition;
            //iBayPosition = iBayPosition;

            //hSingleLoad = hSingleLoad_CNT; // height of each load in mm, 20150830
            //wSingleLoad = wSingleLoad_CNT; // weight of each load in kg, 20150830

            xCGLightShip = 0;
            yCGLightShip = 0;
            zCGLightShip = KG_GC_REAL;


		}

      

        void ChangePointHydrostatic()//calculate hydrostatic
        {


            //GameObject.Find("s0-Ship").GetComponent("WMG_Series").SendMessage("setPointValues", pointSeries0);
            //GameObject.Find("s0-Ship").GetComponent("WMG_Series").SendMessage("setPointValuesChanged", true);

            wPoint0.setPointValues(pointSeries0);
            wPoint0.setPointValuesChanged(true);

            wPoint1.setPointValues(pointSeries1);
            wPoint1.setPointValuesChanged(true);

            wPoint2.setPointValues(pointSeries2);
            wPoint2.setPointValuesChanged(true);

            wPoint3.setPointValues(pointSeries3);
            wPoint3.setPointValuesChanged(true);

            wPoint4.setPointValues(pointSeries4);
            wPoint4.setPointValuesChanged(true);

            wPoint5.setPointValues(pointSeries5);
            wPoint5.setPointValuesChanged(true);

            wPoint6.setPointValues(pointSeries6);
            wPoint6.setPointValuesChanged(true);

            wPoint7.setPointValues(pointSeries7);
            wPoint7.setPointValuesChanged(true);

            wPoint8.setPointValues(pointSeries8);
            wPoint8.setPointValuesChanged(true);

            wPoint9.setPointValues(pointSeries9);
            wPoint9.setPointValuesChanged(true);

            wPoint10.setPointValues(pointSeries10);
            wPoint10.setPointValuesChanged(true);

            wPoint11.setPointValues(pointSeries11);
            wPoint11.setPointValuesChanged(true);

            wPoint25.setPointValues(pointSeries25);
            wPoint25.setPointValuesChanged(true);

            wPoint26.setPointValues(pointSeries26);
            wPoint26.setPointValuesChanged(true);




        }

        void ChangePointCurve()//calculate strength curve
        {
            //ClearPointL();
            //ClearPointT();

            wPoint21.setPointValues(pointSeries21);
            wPoint21.setPointValuesChanged(true);

            wPoint22.setPointValues(pointSeries22);
            wPoint22.setPointValuesChanged(true);

            wPoint23.setPointValues(pointSeries23);
            wPoint23.setPointValuesChanged(true);

            wPoint24.setPointValues(pointSeries24);
            wPoint24.setPointValuesChanged(true);

        }

        void ChangePointLong()
        {


            wPoint12.setPointValues(pointSeries12);
            wPoint12.setPointValuesChanged(true);

            wPoint13.setPointValues(pointSeries13);
            wPoint13.setPointValuesChanged(true);

            wPoint14.setPointValues(pointSeries14);
            wPoint14.setPointValuesChanged(true);

            wPoint15.setPointValues(pointSeries15);
            wPoint15.setPointValuesChanged(true);

            wPoint16.setPointValues(pointSeries16);
            wPoint16.setPointValuesChanged(true);

            wPoint17.setPointValues(pointSeries17);
            wPoint17.setPointValuesChanged(true);

            wPoint18.setPointValues(pointSeries18);
            wPoint18.setPointValuesChanged(true);

            wPoint19.setPointValues(pointSeries19);
            wPoint19.setPointValuesChanged(true);

            wPoint20.setPointValues(pointSeries20);
            wPoint20.setPointValuesChanged(true);

            wPoint27.setPointValues(pointSeries27);
            wPoint27.setPointValuesChanged(true);

            wPoint28.setPointValues(pointSeries28);
            wPoint28.setPointValuesChanged(true);



        }

    #endregion

#region FUNGSI2 & KALIBRASI

		private float DraftR (float ai)//rumus untuk menentukan level sensor
		{

				if (ai >= 6.5) {
						lvDraft = -15.6f;
				} else if (ai >= 6) {
						lvDraft = -13.5f;
				} else if (ai >= 5.5) {
						lvDraft = -12.5f;
				} else if (ai >= 5) {
						lvDraft = -11.7f;
				} else if (ai >= 4.5) {
						lvDraft = -9.8f;
				} else if (ai >= 4) {
						lvDraft = -9.4f;
				} else if (ai >= 3.5) {
						lvDraft = -7.8f;
				} else if (ai >= 3) {
						lvDraft = -6.8f;
				} else if (ai >= 2.5) {
						lvDraft = -5.5f;
				} else if (ai >= 2) {
						lvDraft = -4.4f;
				} else if (ai >= 1.5) {
						lvDraft = -3.5f;
				} else if (ai >= 1) {
						lvDraft = -2.6f;
				} else if (ai >= 0.5) {
						lvDraft = -1.09f;
				} else if (ai >= 0) {
						lvDraft = 0.0f;
				}

				return lvDraft;

		}

        public float DraftKiriDepan(float v_in)//draft
		{
        
                //D1P = 4.2377f * Draft_1P * Draft_1P - 12.953f * Draft_1P + 13.039f;
                //D1S = 4.2377f * Draft_1SB * Draft_1SB - 12.953f * Draft_1SB + 13.039f;//3.0695f * Draft_1SB * Draft_1SB - 5.4894f * Draft_1SB + 5.041f;
                //D2P = 0.8716f * Draft_2P * Draft_2P + 1.7135f * Draft_2P - 3.3736f;
                //D2S = 3.9272f * Draft_2SB * Draft_2SB - 11.831f * Draft_2SB + 11.449f;

//		D1P = -2.6015f * Draft_1P * Draft_1P + 16.201f * Draft_1P - 17.867f;
//		D2P = 5.9213f * Draft_2P * Draft_2P - 20.177f * Draft_2P + 20.983f;
//		D1S = 2.6832f * Draft_1SB * Draft_1SB - 5.5483f * Draft_1SB + 4.6088f;
//		D2S = 10.097f * Draft_2SB * Draft_2SB - 36.547f * Draft_2SB + 37.027f;

            float draft_;


            #region Kalibrasi draft kiri depan
//				if (v_in < 1.769f)
//                {
//				draft_ = -2.6015f * v_in * v_in + 16.201f * v_in - 17.867f;
//                }
//				else 
				if (v_in < 1.935f)
                {
					draft_ = 6.0241f * v_in - 7.6566f;
                }
				else if (v_in < 2.121f)
                {
					draft_ = 5.3763f * v_in - 6.4032f;
                }
                else
                {
					draft_ = 6.7568f * v_in - 9.3311f;
                }

           // draft_ = 12.083f * v_in * v_in * v_in - 74.94f * v_in * v_in + 159.04f * v_in - 111.01f;

            //draft_ = 4.2377f * v_in * v_in - 12.953f * v_in + 13.039f;

			if(draft_<0){
				draft_=0;
			}

            #endregion

                return draft_;
            
		}

        public float DraftKiriBelakang(float v_in)
        {
            float draft_;

            #region Kalibrasi draft kiri belakang

//				if (v_in <= 1.843f)
//                {
//					draft_ = 5.9213f * v_in * v_in - 20.177f * v_in + 20.983f;
//                }
//				else
				if (v_in < 1.931f)
                {
				draft_ = 3.4091f * v_in - 2.583f;
                }
				else if (v_in < 2.077f)
                {
				draft_ =  6.8493f * v_in - 9.226f;
                }
                else
                {
				draft_ = 5.102f * v_in - 5.5969f;
                }

            #endregion

		if(draft_<0){
			draft_=0;
		}

            return draft_;


        }

        public float DraftKananDepan(float v_in)
        {

            float draft_;

            #region Kalibrasi draft kanan depan
//			if (v_in <= 1.745f)
//            {
//                draft_ = 11.364f * v_in - 18.443f;
//            }
//			else 
			if (v_in < 1.911f)
            {
				draft_ = 6.0241f * v_in - 7.512f;
            }
			else if (v_in < 2.087f)
            {
				draft_ = 5.6818f * v_in - 6.858f;
            }
            else
            {
				draft_ =7.3529f * v_in - 10.346f;
            }
		//draft_ = 5.5584f * v_in* v_in* v_in-34.523f* v_in* v_in+75.96f* v_in-54.572f;

            #endregion

		if(draft_<0){
			draft_=0;
		}

            return draft_;




        }

        public float DraftKananBelakang(float v_in)
        {
            float draft_;
            #region Kalibrasi draft kanan belakang
            //if (v_in <= 1.848f)
            //{
            //    draft_ = 9.434f * v_in - 15.962f;
            //}
            //else
			if (v_in < 1.935f)
            {
				draft_ = 2.2989f * v_in - 0.4483f;
            }
			else if (v_in < 2.077f)
            {
				draft_ = 7.0423f * v_in - 9.6268f;
            }
            else
            {
				draft_ = 5.3763f * v_in - 6.1667f;
            }
            #endregion

		if(draft_<0){
			draft_=0;
		}

            return draft_;

        }

        void DraftSim()
        {

            D1P = DraftKiriDepan(Draft_1P);
            D2P = DraftKiriBelakang(Draft_2P);
            D1S = DraftKananDepan(Draft_1SB);
            D2S = DraftKananBelakang(Draft_2SB);

	
            tDraft = (D1P + D2P + D1S + D2S) / 4;


            posYShip = -tDraft - 5.8f;

		shipVessel.transform.position = new Vector3(0, posYShip, 0);
          // print("Draft Total :" + posYShip);

        }
		private float Konv_Sudut (float v_in)
		{
				float v_min, v_max, sudut_min, sudut_max, sudut;

				v_min = 0;
				v_max = 5;

				sudut_min = -30;//spek sensor +-15 degree
				sudut_max = 30;

				sudut = ((sudut_max - sudut_min) / (v_max - v_min)) * (v_in - v_min) + sudut_min;

				return sudut;
		}//konversi sudut

		void RollPitch ()// pitch roll
		{
            shipVessel.transform.localEulerAngles = new Vector3(dHeelVal, 0, -dTrimVal);
		}

		public float ForeSB (float voltIn)
		{

            if (voltIn <= 0.255f)
            {
                voltIn = 0.0f;
            }

				float v3 = voltIn * voltIn * voltIn;
				float v2 = voltIn * voltIn;
				float v1 = voltIn;

              


				float vKGF = 0.0003f * v3 - 0.0255f * v2 + 5.0628f * v1 - 0.0571f;

                if (vKGF < 0)
                {

                    vKGF = 0;
                }

				return vKGF;
		}

		public float ForeP (float voltIn)
		{

            if (voltIn <= 0.255f)
            {
                voltIn = 0.0f;
            }

				float v3 = voltIn * voltIn * voltIn;
				float v2 = voltIn * voltIn;
				float v1 = voltIn;

             
		
				float vKGF = 0.0017f * v3 - 0.0108f * v2 + 5.025f * v1 - 0.038f;

                if (vKGF < 0)
                {

                    vKGF = 0;
                }
		
				return vKGF;


		}

		public float AftP (float voltIn)
		{
            if (voltIn <= 0.255f)
            {
                voltIn = 0.0f;
            }

				

				float v3 = voltIn * voltIn * voltIn;
				float v2 = voltIn * voltIn;
				float v1 = voltIn;

              
		
		float vKGF = 0.0015f * v3 - 0.0133f * v2 + 5.044f * v1 - 0.0675f - 5;

                if (vKGF < 0)
                {

                    vKGF = 0;
                }
		
				return vKGF;
		}

		void TrimList ()
		{
				TrimVal = ((D1P + D1S) / 2) - ((D2P + D2S) / 2);
				ListVal = ((D1P + D2P) / 2) - ((D1S + D2S) / 2);
		}// trim list
		private float LeveleTapeDepan (float voltIn)
		{
            float lvAkuarium;//= (4.0441f * voltIn + 3.7969f) * 2.54f;

            //if (voltIn <= 0.137f)
            //{
            //    voltIn = 0.01f;
            //}

            //    if (voltIn < 2.843f) {
            //            lvAkuarium = 21.053f * voltIn - 23.353f;
            //    } else {
            //            lvAkuarium = 10 * voltIn + 8.07f;

            //    }

            lvAkuarium = 10.521f * voltIn + 7.3031f;


				return lvAkuarium;

		}

		private float LeveleTapeBelakang (float voltIn)
		{
            float lvAkuarium;//= (4.0441f * voltIn + 3.7969f) * 2.54f;
            //if (voltIn <= 0.137f)
            //{
            //    voltIn = 0.01f;
            //}
		
            //    if (voltIn < 2.647f) {
            //            lvAkuarium = 20 * voltIn - 16.44f;
            //    } else {
            //            lvAkuarium = 10 * voltIn + 10.03f;
			
            //    }
            lvAkuarium = 11.397f * voltIn + 7.0417f;
		
				return lvAkuarium;
		
		}

		void waterDB ()//rumus float bottom low high
		{


				DB_1P = DB_1P_L + DB_1SB_H;
				DB_2P = DB_2P_L + DB_2SB_H;
				DB_3P = DB_3P_L + DB_3SB_H;
        
				DB_1SB = DB_1SB_L + DB_1SB_H;
				DB_2SB = DB_2SB_L + DB_2SB_H;
				DB_3SB = DB_3SB_L + DB_3SB_H;

				FCAB = FHAB + FLAB;
				FCFB = FHFB + FLFB;
       

				//------------------DB1 P
				if (DB_1P_L == 0 && DB_1P_H == 0) {//jika DB 1P LOW =0 & DB 1P HIGH =0
						DB_1P = 0.0f;
				} else if (DB_1P_L == 1 && DB_1P_H == 0) {
						DB_1P = 0.5f;
				} else if (DB_1P_L == 1 && DB_1P_H == 1) {
						DB_1P = 1.0f;
				} else {
						print ("ballast error");
				}
				//------------------DB2 P
				if (DB_2P_L == 0 && DB_2P_H == 0) {//jika DB 1P LOW =0 & DB 1P HIGH =0
						DB_2P = 0.0f;
				} else if (DB_2P_L == 1 && DB_2P_H == 0) {
						DB_2P = 0.5f;
				} else if (DB_2P_L == 1 && DB_2P_H == 1) {
						DB_2P = 1.0f;
				} else {
						print ("ballast error");
				}

				//------------------DB3 P
				if (DB_3P_L == 0 && DB_3P_H == 0) {//jika DB 1P LOW =0 & DB 1P HIGH =0
						DB_3P = 0.0f;
				} else if (DB_3P_L == 1 && DB_3P_H == 0) {
						DB_3P = 0.5f;
				} else if (DB_3P_L == 1 && DB_3P_H == 1) {
						DB_3P = 1.0f;
				} else {
						print ("ballast error");
				}
				//------------------DB4 P
       


				//------------DB1 SB
				if (DB_1SB_L == 0 && DB_1SB_H == 0) {//jika DB 1P LOW =0 & DB 1P HIGH =0
						DB_1SB = 0.0f;
				} else if (DB_1SB_L == 1 && DB_1SB_H == 0) {
						DB_1SB = 0.5f;
				} else if (DB_1SB_L == 1 && DB_1SB_H == 1) {
						DB_1SB = 1.0f;
				} else {
						print ("ballast error");
				}


				//------------DB2 SB
				if (DB_2SB_L == 0 && DB_2SB_H == 0) {//jika DB 1P LOW =0 & DB 1P HIGH =0
						DB_2SB = 0.0f;
				} else if (DB_2SB_L == 1 && DB_2SB_H == 0) {
						DB_2SB = 0.5f;
				} else if (DB_2SB_L == 1 && DB_2SB_H == 1) {
						DB_2SB = 1.0f;
				} else {
						print ("ballast error");
				}

				//------------DB3 SB
				if (DB_3SB_L == 0 && DB_3SB_H == 0) {//jika DB 1P LOW =0 & DB 1P HIGH =0
						DB_3SB = 0.0f;
				} else if (DB_3SB_L == 1 && DB_3SB_H == 0) {
						DB_3SB = 0.5f;
				} else if (DB_3SB_L == 1 && DB_3SB_H == 1) {
						DB_3SB = 1.0f;
				} else {
						print ("ballast error");
				}

				//------------FCAB
				if (FLAB == 0 && FHAB == 0) {//jika DB 1P LOW =0 & DB 1P HIGH =0
						FCAB = 0.0f;
				} else if (FLAB == 1 && FHAB == 0) {
						FCAB = 0.5f;
				} else if (FLAB == 1 && FHAB == 1) {
						FCAB = 1.0f;
				} else {
						print ("ballast error");
				}

				//------------FCFB
				if (FLFB == 0 && FHFB == 0) {//jika DB 1P LOW =0 & DB 1P HIGH =0
						FCFB = 0.0f;
				} else if (FLFB == 1 && FHFB == 0) {
						FCFB = 0.5f;
				} else if (FLFB == 1 && FHFB == 1) {
						FCFB = 1.0f;
				} else {
						print ("ballast error");
				}

				//-----------------------------------
				doubleBottom [0].transform.localScale = new Vector3 (1, 1, DB_1P);
				doubleBottom [1].transform.localScale = new Vector3 (1, 1, DB_1SB);
				doubleBottom [2].transform.localScale = new Vector3 (1, 1, DB_2P);
				doubleBottom [3].transform.localScale = new Vector3 (1, 1, DB_2SB);
				doubleBottom [4].transform.localScale = new Vector3 (1, 1, DB_3P);
				doubleBottom [5].transform.localScale = new Vector3 (1, 1, DB_3SB);

				doubleBottom [6].transform.localScale = new Vector3 (1, 1, 0.5f);
				doubleBottom [7].transform.localScale = new Vector3 (1, 1, 0.5f);

				doubleBottom [8].transform.localScale = new Vector3 (1, FCAB, 1);
				doubleBottom [9].transform.localScale = new Vector3 (1, FCFB, 1);

				//doubleBottom[0].transform.localScale = new Vector3(1, DB_1P,1 );
				//doubleBottom[1].transform.localScale = new Vector3(1, DB_2P, 1);
				//doubleBottom[2].transform.localScale = new Vector3(1, DB_3P, 1);
				//doubleBottom[3].transform.localScale = new Vector3(1, DB_4P,1 );

				//doubleBottom[4].transform.localScale = new Vector3(1, DB_1SB, 1);
				//doubleBottom[5].transform.localScale = new Vector3(1, DB_2SB, 1);
				//doubleBottom[6].transform.localScale = new Vector3(1, DB_3SB, 1);
				//doubleBottom[7].transform.localScale = new Vector3(1, DB_4SB, 1);

				//doubleBottom[8].transform.localScale = new Vector3(1, DB_3SB, 1);
				//doubleBottom[9].transform.localScale = new Vector3(1, DB_4SB, 1);

		}

        public float KgtoTon(float _kg)
        {
            float _TON = 50 * 50 * 50 * _kg / 1000;
            return _TON;
        }

        public float mmToM(float _mm)
        {
            float _Meter = 50 * _mm / 1000;
            return _Meter;
        }

    #endregion

#region SIMULASI CONTAINER

	private float LoadF1(float vIn){
		float T1 = 1308.8f * vIn - 658.19f;
		if (T1 < 0)
		{
			T1 = 0;
		}

		return T1;
		
	}

	private float LoadF2(float vIn){

		float T2 = 1122.3f * vIn - 164.81f;
		if (T2 < 0)
		{
			T2 = 0;
		}
		
		return T2;
		
	}
	private float LoadF3(float vIn){

		float T3 = -50.94f * vIn * vIn + 1325.1f * vIn + 57.205f;
		if (T3 < 0)
		{
			T3 = 0;
		}
		
		return T3;
		
	}

	private float LoadF4(float vIn){
		
		float T4 = 1178.4f * vIn - 64.363f;
		if (T4 < 0)
		{
			T4 = 0;
		}
		
		return T4;
		
	}
	
	void loadContainer ()
	{
		
				tH1 = Hold1_1P + Hold1_2P + Hold1_1SB + Hold1_2SB;
				tH2 = Hold2_1P + Hold2_2P + Hold2_1SB + Hold2_2SB;
				tH3 = Hold3_1P + Hold3_2P + Hold3_1SB + Hold3_2SB;
				tH4 = Hold4_1P + Hold4_2P + Hold4_1SB + Hold4_2SB;

//				F1 = 35.81f * tH1 * tH1 * tH1 - 213.51f * tH1 * tH1 + 1412.6f * tH1 - 502;
//                F2 = 70.969f * tH2 * tH2 * tH2 - 537.61f * tH2 * tH2 + 2128.5f * tH2 - 986.76f;
//				F3 = 8.1047f * tH3 * tH3 * tH3 - 108.35f * tH3 * tH3 + 1484.3f * tH3 - 863.06f;
//				F4 = 7.6585f * tH4 * tH4 * tH4 - 81.174f * tH4 * tH4 + 1267.5f * tH4 - 389.77f;

		F1 = LoadF1 (tH1);//1108.2f * tH1 - 193.86f;
		F2 = LoadF2 (tH2);//1059.8f * tH2 - 588.53f;
		F3 = LoadF3 (tH3);//-46.534f * tH3 * tH3 + 1519.8f * tH3 - 69.738f;
		F4 = LoadF4 (tH4);//1088.2f * tH4 - 322.64f;


			
                if (F1 < 0)
                {
                    F1 = 0;
                }
                if (F2 < 0)
                {
                    F2 = 0;
                }
                if (F3 < 0)
                {
                    F3 = 0;
                }
                if (F4 < 0)
                {
                    F4 = 0;
                }

				jCon1 = Mathf.Round ((F1) / 160);
				jCon2 = Mathf.Round ((F2) / 160);
				jCon3 = Mathf.Round ((F3) / 160);
				jCon4 = Mathf.Round ((F4) / 160);


				if (jCon1 > 40) {

						jCon1 = 40;

				}
				if (jCon2 > 50) {

						jCon2 = 50;

				}
				if (jCon3 > 50) {

						jCon3 = 50;

				}
				if (jCon4 > 50) {

						jCon4 = 50;

				}


				jCon = jCon1 + jCon2 + jCon3 + jCon4;
				

				#region TRAY 1

                if (jLama1 != jCon1)
                {
                    for (int i = 0; i < jLama1; i++)
                    {
                        dischargeBRT1();
                    }


						if (jCon1 <= 3) { //kurang dari 3
								
								for (int i = 1; i <= jCon1; i++) {
										int tmp = i - 1;
										selectedBay = "01";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}

						} else if (jCon1 <= 8) { //kurang dari 8
								//print ("kurang dari 8");
								for (int i = 1; i <= 3; i++) {
										int tmp = i - 1;
										selectedBay = "01";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 4; i <= jCon1; i++) {
										int tmp2 = i - 4;
										selectedBay = "03";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}

						} else if (jCon1 <= 11) { //kurang dari 11
								//print ("masuk kurang 11");
								for (int i = 1; i <= 3; i++) {
										int tmp = i - 1;
										selectedBay = "01";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 4; i <= 8; i++) {
										int tmp2 = i - 4;
										selectedBay = "03";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 9; i <= jCon1; i++) {
										int tmp2 = i - 9;
										selectedBay = "01";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}

						} else if (jCon1 <= 16) { //kurang dari 16
								for (int i = 1; i <= 3; i++) {
										int tmp = i - 1;
										selectedBay = "01";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 4; i <= 8; i++) {
										int tmp2 = i - 4;
										selectedBay = "03";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 9; i <= 11; i++) {
										int tmp2 = i - 9;
										selectedBay = "01";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 12; i <= jCon1; i++) {
										int tmp2 = i - 12;
										selectedBay = "03";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}

						} else if (jCon1 <= 19) {// kurang dari 19
								for (int i = 1; i <= 3; i++) {
										int tmp = i - 1;
										selectedBay = "01";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 4; i <= 8; i++) {
										int tmp2 = i - 4;
										selectedBay = "03";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 9; i <= 11; i++) {
										int tmp2 = i - 9;
										selectedBay = "01";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 12; i <= 16; i++) {
										int tmp2 = i - 12;
										selectedBay = "03";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 17; i <= jCon1; i++) {
										int tmp2 = i - 17;
										selectedBay = "01";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}

						} else if (jCon1 <= 24) {// kurang dari 24
								for (int i = 1; i <= 3; i++) {
										int tmp = i - 1;
										selectedBay = "01";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 4; i <= 8; i++) {
										int tmp2 = i - 4;
										selectedBay = "03";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 9; i <= 11; i++) {
										int tmp2 = i - 9;
										selectedBay = "01";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 12; i <= 16; i++) {
										int tmp2 = i - 12;
										selectedBay = "03";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 17; i <= 19; i++) {
										int tmp2 = i - 17;
										selectedBay = "01";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 20; i <= jCon1; i++) {
										int tmp2 = i - 20;
										selectedBay = "03";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}

						} else if (jCon1 <= 27) {// kurang dari 27
								for (int i = 1; i <= 3; i++) {
										int tmp = i - 1;
										selectedBay = "01";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 4; i <= 8; i++) {
										int tmp2 = i - 4;
										selectedBay = "03";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 9; i <= 11; i++) {
										int tmp2 = i - 9;
										selectedBay = "01";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 12; i <= 16; i++) {
										int tmp2 = i - 12;
										selectedBay = "03";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 17; i <= 19; i++) {
										int tmp2 = i - 17;
										selectedBay = "01";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 20; i <= 24; i++) {
										int tmp2 = i - 20;
										selectedBay = "03";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 25; i <= jCon1; i++) {
										int tmp2 = i - 25;
										selectedBay = "01";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}

						} else if (jCon1 <= 32) {// kurang dari 32
								for (int i = 1; i <= 3; i++) {
										int tmp = i - 1;
										selectedBay = "01";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 4; i <= 8; i++) {
										int tmp2 = i - 4;
										selectedBay = "03";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 9; i <= 11; i++) {
										int tmp2 = i - 9;
										selectedBay = "01";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 12; i <= 16; i++) {
										int tmp2 = i - 12;
										selectedBay = "03";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 17; i <= 19; i++) {
										int tmp2 = i - 17;
										selectedBay = "01";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 20; i <= 24; i++) {
										int tmp2 = i - 20;
										selectedBay = "03";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 25; i <= 27; i++) {
										int tmp2 = i - 25;
										selectedBay = "01";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 28; i <= jCon1; i++) {
										int tmp2 = i - 28;
										selectedBay = "03";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
						} else if (jCon1 <= 35) {// kurang dari 35
								for (int i = 1; i <= 3; i++) {
										int tmp = i - 1;
										selectedBay = "01";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 4; i <= 8; i++) {
										int tmp2 = i - 4;
										selectedBay = "03";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 9; i <= 11; i++) {
										int tmp2 = i - 9;
										selectedBay = "01";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 12; i <= 16; i++) {
										int tmp2 = i - 12;
										selectedBay = "03";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 17; i <= 19; i++) {
										int tmp2 = i - 17;
										selectedBay = "01";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 20; i <= 24; i++) {
										int tmp2 = i - 20;
										selectedBay = "03";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 25; i <= 27; i++) {
										int tmp2 = i - 25;
										selectedBay = "01";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 28; i <= 32; i++) {
										int tmp2 = i - 28;
										selectedBay = "03";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 33; i <= jCon1; i++) {
										int tmp2 = i - 33;
										selectedBay = "01";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
						} else if (jCon1 <= 40) {// kurang dari 40

								for (int i = 1; i <= 3; i++) {
										int tmp = i - 1;
										selectedBay = "01";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 4; i <= 8; i++) {
										int tmp2 = i - 4;
										selectedBay = "03";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 9; i <= 11; i++) {
										int tmp2 = i - 9;
										selectedBay = "01";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 12; i <= 16; i++) {
										int tmp2 = i - 12;
										selectedBay = "03";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 17; i <= 19; i++) {
										int tmp2 = i - 17;
										selectedBay = "01";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 20; i <= 24; i++) {
										int tmp2 = i - 20;
										selectedBay = "03";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 25; i <= 27; i++) {
										int tmp2 = i - 25;
										selectedBay = "01";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 28; i <= 32; i++) {
										int tmp2 = i - 28;
										selectedBay = "03";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 33; i <= 35; i++) {
										int tmp2 = i - 33;
										selectedBay = "01";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}
								for (int i = 36; i <= jCon1; i++) {
										int tmp2 = i - 36;
										selectedBay = "03";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT ();
										UpdateLoad1 ();
								}


						}
                        jLama1 = jCon1;

                       // print(" Bay : " + selectedBay + "  Teir :" + selectedTeir + "   Row : " + selectedRow);
                }

						#endregion
						
				#region TRAY 2

                if (jLama2 != jCon2)
                {
                    for (int i = 0; i < jLama2; i++)
                    {
                        dischargeBRT2();
                    }


						if (jCon2 <= 5) { //kurang dari 5

								for (int i = 1; i <= jCon2; i++) {
										int tmp = i - 1;
										selectedBay = "05";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad2 ();

								}

						} else if (jCon2 <= 10) { //kurang dari 10
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "05";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 6; i <= jCon2; i++) {
										int tmp2 = i - 6;
										selectedBay = "07";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}



						} else if (jCon2 <= 15) { //kurang dari 15
								//print ("masuk kurang 15");
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "05";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "07";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 11; i <= jCon2; i++) {
										int tmp2 = i - 11;
										selectedBay = "05";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}

						} else if (jCon2 <= 20) { //kurang dari 20
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "05";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "07";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "05";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 16; i <= jCon2; i++) {
										int tmp2 = i - 16;
										selectedBay = "07";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}

						} else if (jCon2 <= 25) {// kurang dari 25
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "05";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "07";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "05";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "07";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 21; i <= jCon2; i++) {
										int tmp2 = i - 21;
										selectedBay = "05";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}

						} else if (jCon2 <= 30) {// kurang dari 30
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "05";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "07";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "05";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "07";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "05";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 26; i <= jCon2; i++) {
										int tmp2 = i - 26;
										selectedBay = "07";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}

						} else if (jCon2 <= 35) {// kurang dari 35
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "05";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "07";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "05";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "07";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "05";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "07";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 31; i <= jCon2; i++) {
										int tmp2 = i - 31;
										selectedBay = "05";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}

						} else if (jCon2 <= 40) {// kurang dari 40
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "05";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "07";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "05";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "07";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "05";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "07";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 31; i <= 35; i++) {
										int tmp2 = i - 31;
										selectedBay = "05";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 36; i <= jCon2; i++) {
										int tmp2 = i - 36;
										selectedBay = "07";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}

						} else if (jCon2 <= 45) {// kurang dari 45
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "05";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "07";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "05";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "07";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "05";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "07";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 31; i <= 35; i++) {
										int tmp2 = i - 31;
										selectedBay = "05";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 36; i <= 40; i++) {
										int tmp2 = i - 36;
										selectedBay = "07";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 41; i <= jCon2; i++) {
										int tmp2 = i - 41;
										selectedBay = "05";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}

						} else if (jCon2 <= 50) {// kurang dari 50
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "05";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "07";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "05";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "07";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "05";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "07";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 31; i <= 35; i++) {
										int tmp2 = i - 31;
										selectedBay = "05";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 36; i <= 40; i++) {
										int tmp2 = i - 36;
										selectedBay = "07";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 41; i <= 45; i++) {
										int tmp2 = i - 41;
										selectedBay = "05";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}
								for (int i = 46; i <= jCon2; i++) {
										int tmp2 = i - 46;
										selectedBay = "07";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad2 ();
								}

						}
                        jLama2 = jCon2;

                }
						#endregion

				#region TRAY 3

                if (jLama3 != jCon3)
                {
                    for (int i = 0; i < jLama3; i++)
                    {
                        dischargeBRT3();
                    }
						if (jCon3 <= 5) { //kurang dari 5

								for (int i = 1; i <= jCon3; i++) {
										int tmp = i - 1;
										selectedBay = "09";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad3 ();

								}

						} else if (jCon3 <= 10) { //kurang dari 10
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "09";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 6; i <= jCon3; i++) {
										int tmp2 = i - 6;
										selectedBay = "11";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}


						} else if (jCon3 <= 15) { //kurang dari 15
								print ("masuk kurang 15");
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "09";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "11";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 11; i <= jCon3; i++) {
										int tmp2 = i - 11;
										selectedBay = "09";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}

						} else if (jCon3 <= 20) { //kurang dari 20
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "09";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "11";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "09";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 16; i <= jCon3; i++) {
										int tmp2 = i - 16;
										selectedBay = "11";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}

						} else if (jCon3 <= 25) {// kurang dari 25
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "09";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "11";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "09";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "11";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 21; i <= jCon3; i++) {
										int tmp2 = i - 21;
										selectedBay = "09";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}

						} else if (jCon3 <= 30) {// kurang dari 30
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "09";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "11";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "09";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "11";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "09";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 26; i <= jCon3; i++) {
										int tmp2 = i - 26;
										selectedBay = "11";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}

						} else if (jCon3 <= 35) {// kurang dari 35
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "09";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "11";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "09";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "11";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "09";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "11";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 31; i <= jCon3; i++) {
										int tmp2 = i - 31;
										selectedBay = "09";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}

						} else if (jCon3 <= 40) {// kurang dari 40
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "09";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "11";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "09";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "11";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "09";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "11";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 31; i <= 35; i++) {
										int tmp2 = i - 31;
										selectedBay = "09";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 36; i <= jCon3; i++) {
										int tmp2 = i - 36;
										selectedBay = "11";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}

						} else if (jCon3 <= 45) {// kurang dari 45
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "09";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "11";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "09";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "11";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "09";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "11";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 31; i <= 35; i++) {
										int tmp2 = i - 31;
										selectedBay = "09";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 36; i <= 40; i++) {
										int tmp2 = i - 36;
										selectedBay = "11";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 41; i <= jCon3; i++) {
										int tmp2 = i - 41;
										selectedBay = "09";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}

						} else if (jCon3 <= 50) {// kurang dari 50
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "09";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "11";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "09";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "11";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "09";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "11";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 31; i <= 35; i++) {
										int tmp2 = i - 31;
										selectedBay = "09";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 36; i <= 40; i++) {
										int tmp2 = i - 36;
										selectedBay = "11";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 41; i <= 45; i++) {
										int tmp2 = i - 41;
										selectedBay = "09";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}
								for (int i = 46; i <= jCon3; i++) {
										int tmp2 = i - 46;
										selectedBay = "11";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad3 ();
								}

						}
                        jLama3 = jCon3;
                }
						#endregion
						
				#region TRAY 4
                if (jLama4 != jCon4)
                {
                    for (int i = 0; i < jLama4; i++)
                    {
                        dischargeBRT4();
                    }
						if (jCon4 <= 5) { //kurang dari 5

								for (int i = 1; i <= jCon4; i++) {
										int tmp = i - 1;
										selectedBay = "13";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad4 ();

								}

						} else if (jCon4 <= 10) { //kurang dari 10
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "13";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 6; i <= jCon4; i++) {
										int tmp2 = i - 6;
										selectedBay = "15";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}


						} else if (jCon4 <= 15) { //kurang dari 15
								print ("masuk kurang 15");
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "13";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "15";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 11; i <= jCon4; i++) {
										int tmp2 = i - 11;
										selectedBay = "13";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}

						} else if (jCon4 <= 20) { //kurang dari 20
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "13";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "15";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "13";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 16; i <= jCon4; i++) {
										int tmp2 = i - 16;
										selectedBay = "15";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}

						} else if (jCon4 <= 25) {// kurang dari 25
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "13";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "15";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
                                        UpdateLoad4();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "13";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "15";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 21; i <= jCon4; i++) {
										int tmp2 = i - 21;
										selectedBay = "13";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}

						} else if (jCon4 <= 30) {// kurang dari 30
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "13";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "15";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "13";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "15";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "13";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 26; i <= jCon4; i++) {
										int tmp2 = i - 26;
										selectedBay = "15";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}

						} else if (jCon4 <= 35) {// kurang dari 35
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "13";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "15";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "13";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "15";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "13";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "15";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 31; i <= jCon4; i++) {
										int tmp2 = i - 31;
										selectedBay = "13";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}

						} else if (jCon4 <= 40) {// kurang dari 40
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "13";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "15";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "13";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "15";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "13";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "15";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 31; i <= 35; i++) {
										int tmp2 = i - 31;
										selectedBay = "13";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 36; i <= jCon4; i++) {
										int tmp2 = i - 36;
										selectedBay = "15";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}

						} else if (jCon4 <= 45) {// kurang dari 45
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "13";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "15";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "13";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "15";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "13";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "15";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 31; i <= 35; i++) {
										int tmp2 = i - 31;
										selectedBay = "13";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 36; i <= 40; i++) {
										int tmp2 = i - 36;
										selectedBay = "15";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 41; i <= jCon4; i++) {
										int tmp2 = i - 41;
										selectedBay = "13";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}

						} else if (jCon4 <= 50) {// kurang dari 50
								for (int i = 1; i <= 5; i++) {
										int tmp = i - 1;
										selectedBay = "13";
										selectedTeir = "02";
										selectedRow = "0" + tmp.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 6; i <= 10; i++) {
										int tmp2 = i - 6;
										selectedBay = "15";
										selectedTeir = "02";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 11; i <= 15; i++) {
										int tmp2 = i - 11;
										selectedBay = "13";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 16; i <= 20; i++) {
										int tmp2 = i - 16;
										selectedBay = "15";
										selectedTeir = "04";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 21; i <= 25; i++) {
										int tmp2 = i - 21;
										selectedBay = "13";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 26; i <= 30; i++) {
										int tmp2 = i - 26;
										selectedBay = "15";
										selectedTeir = "06";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 31; i <= 35; i++) {
										int tmp2 = i - 31;
										selectedBay = "13";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 36; i <= 40; i++) {
										int tmp2 = i - 36;
										selectedBay = "15";
										selectedTeir = "82";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 41; i <= 45; i++) {
										int tmp2 = i - 41;
										selectedBay = "13";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}
								for (int i = 46; i <= jCon4; i++) {
										int tmp2 = i - 46;
										selectedBay = "15";
										selectedTeir = "84";
										selectedRow = "0" + tmp2.ToString ();
										posBRT2 ();
										UpdateLoad4 ();
								}


						}
                        jLama4 = jCon4;

                }
						#endregion
						
			

				sdhTaruh = true;
		}

		void posBRT ()//posisi bay,row,teir
		{
				//---POSISI BAY
				if (selectedBay == "01") {
						posBay = 56.7699f;
				} else if (selectedBay == "03") {
						posBay = 44.79334f;
				} else if (selectedBay == "05") {//hold2
						posBay = 24.33986f;
				} else if (selectedBay == "07") {
						posBay = 12.221f;
				} else if (selectedBay == "09") {
						posBay = 0.1751568f;
				} else if (selectedBay == "11") {
						posBay = -11.87069f;
				} else if (selectedBay == "13") {
						posBay = -35.09938f;
				} else if (selectedBay == "15") {
						posBay = -47.0737f;
				} else {
						message = "bay kosong";
				}

				//--POSISI ROW
				if (selectedRow == "04") {
						posRow = -10.07844f;
				} else if (selectedRow == "02") {
						posRow = -4.998358f;
				} else if (selectedRow == "00") {
						posRow = -1.050507e-06f;
				} else if (selectedRow == "01") {
						posRow = 5.167669f;
				} else if (selectedRow == "03") {
						posRow = 10.24775f;
				} else {
						message = "Row kosong";
				}

				//--POSISI TEIR
				if (selectedTeir == "02") {
                    posTeir = 9.240688f + posYShip;
				} else if (selectedTeir == "04") {
                    posTeir = 13.8777f + posYShip;
				} else if (selectedTeir == "06") {
                    posTeir = 18.51301f + posYShip;
				} else if (selectedTeir == "82") {
                    posTeir = 23.15195f + posYShip;
				} else if (selectedTeir == "84") {
                    posTeir = 27.79199f + posYShip;
				} else {
						message = "Teir kosong";
				}

		}

        void posBRT2()//posisi bay,row,teir
        {
            //---POSISI BAY
            if (selectedBay == "01")
            {
                posBay = 56.7699f;
            }
            else if (selectedBay == "03")
            {
                posBay = 44.79334f;
            }
            else if (selectedBay == "05")
            {//hold2
                posBay = 24.33986f;
            }
            else if (selectedBay == "07")
            {
                posBay = 12.221f;
            }
            else if (selectedBay == "09")
            {
                posBay = 0.1751568f;
            }
            else if (selectedBay == "11")
            {
                posBay = -11.87069f;
            }
            else if (selectedBay == "13")
            {
                posBay = -35.09938f;
            }
            else if (selectedBay == "15")
            {
                posBay = -47.0737f;
            }
            else
            {
                message = "bay kosong";
            }

            //--POSISI ROW
            if (selectedRow == "04")
            {
                posRow = -10.07844f;
            }
            else if (selectedRow == "02")
            {
                posRow = -4.998358f;
            }
            else if (selectedRow == "00")
            {
                posRow = -1.050507e-06f;
            }
            else if (selectedRow == "01")
            {
                posRow = 5.167669f;
            }
            else if (selectedRow == "03")
            {
                posRow = 10.24775f;
            }
            else
            {
                message = "Row kosong";
            }

            //--POSISI TEIR
            if (selectedTeir == "02")
            {
                posTeir = 6.33826f + posYShip;
            }
            else if (selectedTeir == "04")
            {
                posTeir = 10.97776f + posYShip;
            }
            else if (selectedTeir == "06")
            {
                posTeir = 15.61498f + posYShip;
            }
            else if (selectedTeir == "82")
            {
                posTeir = 20.25176f + posYShip;
            }
            else if (selectedTeir == "84")
            {
                posTeir = 24.8918f + posYShip;
            }
            else
            {
                message = "Teir kosong";
            }

        }

        //void posBRTStack()//posisi bay,row,teir
        //{
        //    //---POSISI BAY
        //    if (selectedBay == "01")
        //    {
        //        posBay = 56.7699f;
        //    }
        //    else if (selectedBay == "03")
        //    {
        //        posBay = 44.79334f;
        //    }
        //    else if (selectedBay == "05")
        //    {//hold2
        //        posBay = 24.33986f;
        //    }
        //    else if (selectedBay == "07")
        //    {
        //        posBay = 12.221f;
        //    }
        //    else if (selectedBay == "09")
        //    {
        //        posBay = 0.1751568f;
        //    }
        //    else if (selectedBay == "11")
        //    {
        //        posBay = -11.87069f;
        //    }
        //    else if (selectedBay == "13")
        //    {
        //        posBay = -35.09938f;
        //    }
        //    else if (selectedBay == "15")
        //    {
        //        posBay = -47.0737f;
        //    }
        //    else
        //    {
        //        message = "bay kosong";
        //    }

        //    //--POSISI ROW
        //    if (selectedRow == "04")
        //    {
        //        posRow = -10.07844f;
        //    }
        //    else if (selectedRow == "02")
        //    {
        //        posRow = -4.998358f;
        //    }
        //    else if (selectedRow == "00")
        //    {
        //        posRow = -1.050507e-06f;
        //    }
        //    else if (selectedRow == "01")
        //    {
        //        posRow = 5.167669f;
        //    }
        //    else if (selectedRow == "03")
        //    {
        //        posRow = 10.24775f;
        //    }
        //    else
        //    {
        //        message = "Row kosong";
        //    }

        //    //--POSISI TEIR
        //    if (selectedTeir == "01")
        //    {
        //        posTeir = 1.1f + posYShipM;
        //    }
        //    else if (selectedTeir == "02")
        //    {
        //        posTeir = 6.1f + posYShipM;
        //    }
        //    else if (selectedTeir == "03")
        //    {
        //        posTeir = 11.1f + posYShipM;
        //    }
        //    else if (selectedTeir == "04")
        //    {
        //        posTeir = 16.1f + posYShipM;
        //    }
        //    else if (selectedTeir == "05")
        //    {
        //        posTeir = 21.1f + posYShipM;
        //    }
        //    else
        //    {
        //        message = "Teir kosong";
        //    }

        //}

        void posBRTStack()//posisi bay,row,teir
        {
            //---POSISI BAY
            if (selectedBay == "01")
            {
                posBay = 56.7699f;
            }
            else if (selectedBay == "03")
            {
                posBay = 44.79334f;
            }
            else if (selectedBay == "05")
            {//hold2
                posBay = 24.33986f;
            }
            else if (selectedBay == "07")
            {
                posBay = 12.221f;
            }
            else if (selectedBay == "09")
            {
                posBay = 0.1751568f;
            }
            else if (selectedBay == "11")
            {
                posBay = -11.87069f;
            }
            else if (selectedBay == "13")
            {
                posBay = -35.09938f;
            }
            else if (selectedBay == "15")
            {
                posBay = -47.0737f;
            }
            else
            {
                message = "bay kosong";
            }

            //--POSISI ROW
            if (selectedRow == "04")
            {
                posRow = -10.07844f;
            }
            else if (selectedRow == "02")
            {
                posRow = -4.998358f;
            }
            else if (selectedRow == "00")
            {
                posRow = -1.050507e-06f;
            }
            else if (selectedRow == "01")
            {
                posRow = 5.167669f;
            }
            else if (selectedRow == "03")
            {
                posRow = 10.24775f;
            }
            else
            {
                message = "Row kosong";
            }

            //--POSISI TEIR
            if (selectedTeir == "01")
            {
                posTeir = 5.1f + posYShipM;
            }
            else if (selectedTeir == "02")
            {
                posTeir = 10.1f + posYShipM;
            }
            else if (selectedTeir == "03")
            {
                posTeir = 15.1f + posYShipM;
            }
            else if (selectedTeir == "04")
            {
                posTeir = 20.1f + posYShipM;
            }
            else if (selectedTeir == "05")
            {
                posTeir = 25.1f + posYShipM;
            }
            else
            {
                message = "Teir kosong";
            }

        }

		void loadBRT ()//fungsi load kontener
		{
				posBRT ();

               


				if (posBay == 0 && posTeir == 0 && posRow == 0) {
						message = "can't loading";
				} else if (posBay == 0) {
						message = "bay harus di isi";
				} else if (posRow == 0) {
						message = "Row harus di isi";
				} else if (posTeir == 0) {
						message = "Teir harus di isi";
                }
                //else if (selectedTeir == "84" || selectedTeir == "82" || selectedTeir == "06" || selectedTeir == "04")
                //{
                //        message = "can't loading";
   
                //}
                else{

						UpdateLoad1 ();
				}

               


		}

		void unloadBRT ()//fungsi unload kontener
		{
				posBRT ();


				if (posBay == 0 && posTeir == 0 && posRow == 0) {
						message = "can't unloading";
				} else if (posBay == 0) {
						message = "bay harus di isi";
				} else if (posRow == 0) {
						message = "Row harus di isi";
				} else if (posTeir == 0) {
						message = "Teir harus di isi";
				} else {
						dischargeBRT1 ();
				}

		}

		void UpdateLoad1 ()
		{
				Vector3 _pos;
				_pos.x = posBay;
				_pos.y = posTeir;
				_pos.z = posRow;

				Quaternion _rot = transform.rotation;
				_child = Instantiate (container1, _pos, _rot) as Transform;
				_child.transform.parent = this.transform;

				message = "Bay  :" + selectedBay + "   Row  :" + selectedRow + "   Teir  :" + selectedTeir;
				//resetBRT();
		}

        void UpdateStack()
        {
            Vector3 _pos;
            _pos.x = posBay;
            _pos.y = posTeir;
            _pos.z = posRow;

            Quaternion _rot = transform.rotation;
            _child = Instantiate(cont_sim, _pos, _rot) as Transform;
            _child.transform.parent = this.transform;

            message = "Bay  :" + selectedBay + "   Row  :" + selectedRow + "   Teir  :" + selectedTeir;
            //resetBRT();
        }

        void loadStack()
        {

            float tStack = sldTier;




            jStack = tStack;

            if (jLama != jStack)
            {
                for (int i = 0; i < jLama; i++)
                {
                    dischargeBRT();
                }

                if (jStack <= 5)
                {
                    for (int i = 1; i < jStack; i++)
                    {
                        int tmp = i + 1;
                        selectedTeir = "0" + tmp.ToString();
                        posBRTStack();
                        UpdateStack();
           
                    }
                }
               
            }

          

           // print("Total muatan baru :" + BobotTotal);

            sdhTaruh = true;
           
            
            

        }
      
		void UpdateLoad2 ()
		{
				Vector3 _pos;
				_pos.x = posBay;
				_pos.y = posTeir;
				_pos.z = posRow;

				Quaternion _rot = transform.rotation;
				_child = Instantiate (container2, _pos, _rot) as Transform;
				_child.transform.parent = this.transform;

				message = "Bay  :" + selectedBay + "   Row  :" + selectedRow + "   Teir  :" + selectedTeir;
				//resetBRT();
		}

		void UpdateLoad3 ()
		{
				Vector3 _pos;
				_pos.x = posBay;
				_pos.y = posTeir;
				_pos.z = posRow;

				Quaternion _rot = transform.rotation;
				_child = Instantiate (container3, _pos, _rot) as Transform;
				_child.transform.parent = this.transform;

				message = "Bay  :" + selectedBay + "   Row  :" + selectedRow + "   Teir  :" + selectedTeir;
				//resetBRT();
		}

		void UpdateLoad4 ()
		{
				Vector3 _pos;
				_pos.x = posBay;
				_pos.y = posTeir;
				_pos.z = posRow;

				Quaternion _rot = transform.rotation;
				_child = Instantiate (container4, _pos, _rot) as Transform;
				_child.transform.parent = this.transform;

				message = "Bay  :" + selectedBay + "   Row  :" + selectedRow + "   Teir  :" + selectedTeir;
				//resetBRT();
		}

		void dischargeBRT1 ()
		{
     
				GameObject[] kon1;
				kon1 = GameObject.FindGameObjectsWithTag ("container");
				for (int i = 0; i < kon1.Length; i++) {
						DestroyImmediate(kon1 [i].gameObject);
				}
		}

		void dischargeBRT2 ()
		{

				GameObject[] kon2;
				kon2 = GameObject.FindGameObjectsWithTag ("container2");
				for (int i = 0; i < kon2.Length; i++) {
						Destroy (kon2 [i].gameObject);
				}
		}

		void dischargeBRT3 ()
		{

				GameObject[] kon3;
				kon3 = GameObject.FindGameObjectsWithTag ("container3");
				for (int i = 0; i < kon3.Length; i++) {
						Destroy (kon3 [i].gameObject);
				}
		}

		void dischargeBRT4 ()
		{

				GameObject[] kon4;
				kon4 = GameObject.FindGameObjectsWithTag ("container4");
				for (int i = 0; i < kon4.Length; i++) {
						Destroy (kon4 [i].gameObject);
				}
		}

        void MoveContainer()
        {
            GameObject[] kon;
            kon = GameObject.FindGameObjectsWithTag("con_sim");
            posBRTStack();


            if (selectedBay == "01" || selectedBay == "03" || selectedBay == "05" || selectedBay == "07" 
             || selectedBay == "09" || selectedBay == "11" || selectedBay == "13" || selectedBay == "15")
            {

                for (int i = 0; i < kon.Length; i++)
                {
                    kon[i].transform.localPosition = new Vector3(posBay, posTeir, 0);

                    print("posisi bay ;" + posBay);

                }
            }
            
            //Destroy (container.gameObject);
            message = "Bay  :" + selectedBay + "   Row  :" + selectedRow + "   Teir  :" + selectedTeir;
            //resetBRT();


        }

		void dischargeBRT ()
		{
            GameObject[] kon;
            kon = GameObject.FindGameObjectsWithTag("con_sim");
            for (int i = 0; i < kon.Length; i++)
            {
                Destroy(kon[i].gameObject);
            }
				//Destroy (container.gameObject);
				message = "Bay  :" + selectedBay + "   Row  :" + selectedRow + "   Teir  :" + selectedTeir;
				resetBRT ();
		}

		void resetBRT ()
		{
				selectedBay = "";
				selectedRow = "";
				selectedTeir = "";
				posBay = 0;
				posRow = 0;
				posTeir = 0;
		}

    #endregion

#region FORM WINDOW

        void OnGUI()
        {


        #region Menu



        //if (GUI.Button(new Rect(420 + posX, 50, btWidth, btnHeight), "Comm"))
        //{
        //    // chart2d.active = false;
        //    Port.active = !Port.active;
        //}

        //if (GUI.Button(new Rect(520 + posX, 50, btWidth, btnHeight), "View Mode"))
        //{
        //    menuMode = !menuMode;// true;
        //}
        //if (menuMode)
        //{
        //    frmMode = GUI.Window(1, frmMode, formMode, "Mode/FX");
        //    menuMode = true;
        //}

        //if (GUI.Button(new Rect(660 + posX, 200, btWidth, btnHeight), "Simulation"))
        //{
        //    //camChart.active = false;
        //    // 
        //    menuSim = !menuSim;
        //}


        //if (Input.GetKey("p"))
        //{

        //    menuSim = !menuSim;

        //}

        //if (menuSim)
        //{
        //    frmSimulasi = GUI.Window(4, frmSimulasi, formSimulasi, "Simulation");
        //    menuSim = true;
        //    //print("aktif");
        //}

        //if (GUI.Button(new Rect(620 + posX, 50, btWidth, btnHeight), "Monitoring"))
        //{
        //    //// true;
        //    menuCalib = !menuCalib;// true;
        //    print("Calibration");
        //}
        //if (menuCalib)
        //{
        //    frmCalib = GUI.Window(3, frmCalib, formMonitoring, "Monitoring");
        //    menuCalib = true;
        //}

        //if (GUI.Button(new Rect(720 + posX, 50, btWidth, btnHeight), "Curve"))
        //{
        //    camChart.active = !camChart.active;
        //    CalculateStrengthCurve_CS();
        //    //DrawHydrostaticCurve();
        //}

        //if (GUI.Button(new Rect(820 + posX, 50, btWidth, btnHeight), "Stability Points"))
        //{
        //    //menuInput = !menuInput;// true;
        //    chart2d.active = !chart2d.active;

        //    print("Input");
        //}


        //if (GUI.Button(new Rect(920 + posX, 850, btWidth, btnHeight), "Input Data"))
        //{
        //    menuInput = !menuInput;
        //    menuInfo = !menuInfo;
        //}

        if (menuInput)
            {
                frmBRT = GUI.Window(2, frmBRT, formBRT, "Object Payload");
                //  frmViewInfo = GUI.Window(6, frmViewInfo, infoMoveTrim, "Result");
                // menuInfo = true;
                //infoMoveTrim();
                menuInput = true;
            }


		//if (GUI.Button(new Rect(1020 + posX, 50, btWidth, btnHeight), "Help"))
		//{
		//    //Application.Quit ();
		//    menuHelp = !menuHelp;
		//    print("Help");
		//}
		//if (menuHelp)
		//{
		//    frmHelp = GUI.Window(5, frmHelp, formHelp, "Help");
		//    menuHelp = true;
		//}


		//// GUI FOR BALLAST MODE AUTO MANUAL ===============================================
		//if (GUI.Button(new Rect(500 + posX, 50, btWidth, btnHeight), "Ballast MD"))
		//{
		//    menuBallastMode = !menuBallastMode;
		//    //print("Ballast Mode");
		//}
		//if (menuBallastMode)
		//{
		//    GUI.Box(new Rect(500 + posX, 85, btWidth, btnHeight), "");
		//    GUI.Box(new Rect(500 + posX, 130, 500, 200), "Ballast Mode");
		//    GUI.Label(new Rect(510 + posX, 160, 100, 30), "Ballast Mode :");

		//    if (GUI.Button(Box, BallastselectedItem))
		//    {
		//        editing = true;
		//    }
		//    if (editing)
		//    {
		//        for (int x = 0; x < BallastModeItems.Length; x++)
		//        {
		//            if (GUI.Button(new Rect(Box.x, (Box.height * x) + Box.y + Box.height, Box.width, Box.height), BallastModeItems[x]))
		//            {
		//                if (data != null)
		//                {
		//                    if (data.SerialPort != null)
		//                    {
		//                        if (data.SerialPort.IsOpen)
		//                        {
		//                            BallastselectedItem = BallastModeItems[x];
		//                            BallastMode = x;
		//                        }
		//                    }
		//                }
		//                editing = false;

		//            }
		//        }
		//    }


		//}
		//else
		//{
		//    //print("EXIT MENU BALLAST MODE");
		//}
		//// GUI FOR BALLAST MODE AUTO MANUAL ===============================================

		//if (GUI.Button(new Rect(1120 + posX, 50, btWidth, btnHeight), "Exit"))
		//{
		//    menuExit = !menuExit;// true;
		//    print("Exit");
		//}
		//if (menuExit)
		//{
		//    frmExit = GUI.Window(5, frmExit, formExit, "Exit Application ?");
		//    menuExit = true;

		//}
		#endregion


		RollPitch();
		DraftSim();

		//         RollPitch();
		//DraftSim ();

		CalculateTranverseHydrostatic();
            CalculateLongHydrostatic();
            

           
            print("G Load Trans : " + GLoadTotalTransversal.ToString("F2"));




        }//menu utama

    

        public void fromAI()
        {

            TrimList();
          

           // shipVessel.transform.localEulerAngles = new Vector3(Konv_Sudut(sldList), 0, Konv_Sudut(sldTrim));

            DraftSim();

            loadContainer();
            waterDB();

        }

    void DataAI()
    {

       // data = GetComponent<UnitySerialPort>();


        Hold1_1P    = float.Parse(data.AIData[0]);
        Hold1_2P    = float.Parse(data.AIData[1]);
        Hold1_1SB   = float.Parse(data.AIData[2]);
        Hold1_2SB   = float.Parse(data.AIData[3]);

        Hold2_1P    = float.Parse(data.AIData[4]);
        Hold2_2P    = float.Parse(data.AIData[5]);
        Hold2_1SB   = float.Parse(data.AIData[6]);
        Hold2_2SB   = float.Parse(data.AIData[7]);

        Hold3_1P    = float.Parse(data.AIData[8]);
        Hold3_2P    = float.Parse(data.AIData[9]);
        Hold3_1SB   = float.Parse(data.AIData[10]);
        Hold3_2SB = float.Parse(data.AIData[11]);

        Hold4_1P = float.Parse(data.AIData[12]);
        Hold4_2P = float.Parse(data.AIData[13]);
        Hold4_1SB = float.Parse(data.AIData[14]);
        Hold4_2SB = float.Parse(data.AIData[15]);

        sldList = float.Parse(data.AIData[17]);
        sldTrim = float.Parse(data.AIData[16]);

        Draft_1P = float.Parse(data.AIData[18]);
        Draft_1SB = float.Parse(data.AIData[19]);
        Draft_2P = float.Parse(data.AIData[20]);
        Draft_2SB = float.Parse(data.AIData[21]);
        // Draft_3P = float.Parse(data.AIData[20]);
        // Draft_3SB = float.Parse(data.AIData[23]);

        //LOAD CELL
        AF1P = float.Parse(data.AIData[26]);
        AF2P = float.Parse(data.AIData[24]);

        AF1SB = float.Parse(data.AIData[27]);
        AF2SB = float.Parse(data.AIData[25]);

        //level akuarium
        lvAkuariumF = float.Parse(data.AIData[28]);
        lvAkuariumB = float.Parse(data.AIData[29]);

        DB_1P_L = float.Parse(data.AIDataLH[0]);
        DB_2P_L = float.Parse(data.AIDataLH[1]);
        DB_3P_L = float.Parse(data.AIDataLH[2]);

        DB_1SB_L = float.Parse(data.AIDataLH[3]);
        DB_2SB_L = float.Parse(data.AIDataLH[4]);
        DB_3SB_L = float.Parse(data.AIDataLH[5]);

        FLAB = float.Parse(data.AIDataLH[6]);
        FLFB = float.Parse(data.AIDataLH[7]);



        DB_1P_H = float.Parse(data.AIDataLH[10]);
        DB_2P_H = float.Parse(data.AIDataLH[11]);
        DB_3P_H = float.Parse(data.AIDataLH[12]);

        DB_1SB_H = float.Parse(data.AIDataLH[13]);
        DB_2SB_H = float.Parse(data.AIDataLH[14]);
        DB_3SB_H = float.Parse(data.AIDataLH[15]);


        FHAB = float.Parse(data.AIDataLH[16]);
        FHFB = float.Parse(data.AIDataLH[17]);
        //       FCFB = float.Parse(data.AIDataLH[20]);
        //        FCAB = float.Parse(data.AIDataLH[21]);


    } //nerima data AI
        void formInput(int windowID)
        {

            GUI.Label(new Rect(20, 40, 100, 30), "Hold1 P");
            Hold1_1P = GUI.HorizontalSlider(new Rect(80, 45, 100, 30), Hold1_1P, minIn, maxIn);
            // GUI.TextField(new Rect(200, 40, 100, 30), "" + Hold1_1P.ToString("#0.00"));


            editHodl1P = GUI.TextField(new Rect(200, 40, 100, 30), editHodl1P, 25);

            GUI.Label(new Rect(20, 70, 100, 30), "Hold2 P");
            Hold2_1P = GUI.HorizontalSlider(new Rect(80, 75, 100, 30), Hold2_1P, minIn, maxIn);
            GUI.Label(new Rect(200, 70, 100, 30), "" + Hold2_1P.ToString("#0.00"));

            GUI.Label(new Rect(20, 100, 100, 30), "Hold3 P");
            Hold3_1P = GUI.HorizontalSlider(new Rect(80, 105, 100, 30), Hold3_1P, minIn, maxIn);
            GUI.Label(new Rect(200, 100, 100, 30), "" + Hold3_1P.ToString("#0.00"));

            GUI.Label(new Rect(280, 40, 100, 30), "Hold1 SB");
            Hold1_1SB = GUI.HorizontalSlider(new Rect(345, 45, 100, 30), Hold1_1SB, minIn, maxIn);
            GUI.Label(new Rect(460, 40, 100, 30), "" + Hold1_1SB.ToString("#0.00"));

            GUI.Label(new Rect(280, 70, 100, 30), "Hold2 SB");
            Hold2_1SB = GUI.HorizontalSlider(new Rect(345, 75, 100, 30), Hold2_1SB, minIn, maxIn);
            GUI.Label(new Rect(460, 70, 100, 30), "" + Hold2_1SB.ToString("#0.00"));

            GUI.Label(new Rect(280, 100, 100, 30), "Hold3 SB");
            Hold3_1SB = GUI.HorizontalSlider(new Rect(345, 105, 100, 30), Hold3_1SB, minIn, maxIn);
            GUI.Label(new Rect(460, 100, 100, 30), "" + Hold3_1SB.ToString("#0.00"));

            GUI.DragWindow();



        }

        void formHelp(int windowID)
        {

            GUI.Box(new Rect(100, 30, 150, 25), "Camera Controller");

            GUI.Box(new Rect(25, 70, 25, 25), "W");

            GUI.Label(new Rect(60, 70, 100, 25), ": Up");

            GUI.Box(new Rect(25, 100, 25, 25), "A");

            GUI.Label(new Rect(60, 100, 100, 25), ": Left");

            GUI.Box(new Rect(25, 130, 25, 25), "S");

            GUI.Label(new Rect(60, 130, 100, 25), ": Down");

            GUI.Box(new Rect(25, 160, 25, 25), "D");

            GUI.Label(new Rect(60, 160, 100, 25), ": Right");

            //---------------------------------------------------------
            GUI.Box(new Rect(150, 70, 100, 25), "Key.Up");

            GUI.Label(new Rect(275, 70, 100, 25), ": Up");

            GUI.Box(new Rect(150, 100, 100, 25), "Key.Left");

            GUI.Label(new Rect(275, 100, 100, 25), ": Left");

            GUI.Box(new Rect(150, 130, 100, 25), "Key.Down");

            GUI.Label(new Rect(275, 130, 100, 25), ": Down");

            GUI.Box(new Rect(150, 160, 100, 25), "Key.Right");

            GUI.Label(new Rect(275, 160, 100, 25), ": Right");

            GUI.DragWindow();



        }
		void activeBallastTank ()
		{
		
				// ---------SIDE TANK
				GUI.Label (new Rect (20, 50, 150, 30), "FP T");
				FCFB = GUI.HorizontalSlider (new Rect (75, 55, 100, 30), FCFB, minIn, maxIn);
				GUI.Label (new Rect (190, 50, 100, 30), "" + FCFB.ToString ("#0.000"));
		
				GUI.Label (new Rect (280, 50, 150, 30), "DBWB");
				FCAB = GUI.HorizontalSlider (new Rect (345, 55, 100, 30), FCAB, minIn, maxIn);
				GUI.Label (new Rect (460, 50, 100, 30), "" + FCAB.ToString ("#0.000"));
		
				//----------------------------------------------------------------------------------------------------
				GUI.Label (new Rect (20, 80, 150, 30), "DB 1P L");
				DB_1P_L = GUI.HorizontalSlider (new Rect (75, 85, 100, 30), DB_1P_L, minIn, maxIn);
				GUI.Label (new Rect (190, 80, 100, 30), "" + DB_1P_L.ToString ("#0.000"));
		
				GUI.Label (new Rect (20, 110, 150, 30), "DB 2P L");
				DB_2P_L = GUI.HorizontalSlider (new Rect (75, 115, 100, 30), DB_2P_L, minIn, maxIn);
				GUI.Label (new Rect (190, 110, 100, 30), "" + DB_2P_L.ToString ("#0.000"));
		
				GUI.Label (new Rect (20, 140, 150, 30), "DB 3P L");
				DB_3P_L = GUI.HorizontalSlider (new Rect (75, 145, 100, 30), DB_3P_L, minIn, maxIn);
				GUI.Label (new Rect (190, 140, 100, 30), "" + DB_3P_L.ToString ("#0.000"));
		
				GUI.Label (new Rect (20, 170, 150, 30), "DB 1P H");
				DB_1P_H = GUI.HorizontalSlider (new Rect (75, 175, 100, 30), DB_1P_H, minIn, maxIn);
				GUI.Label (new Rect (190, 170, 100, 30), "" + DB_1P_H.ToString ("#0.000"));
		
				GUI.Label (new Rect (20, 200, 150, 30), "DB 2P H");
				DB_2P_H = GUI.HorizontalSlider (new Rect (75, 205, 100, 30), DB_2P_H, minIn, maxIn);
				GUI.Label (new Rect (190, 200, 100, 30), "" + DB_2P_H.ToString ("#0.000"));
		
				GUI.Label (new Rect (20, 230, 150, 30), "DB 3P H");
				DB_3P_H = GUI.HorizontalSlider (new Rect (75, 235, 100, 30), DB_3P_H, minIn, maxIn);
				GUI.Label (new Rect (190, 230, 100, 30), "" + DB_3P_H.ToString ("#0.000"));
		
				GUI.Label (new Rect (20, 270, 150, 30), "FWT P");
				FHFWTP = GUI.HorizontalSlider (new Rect (75, 275, 100, 30), FHFWTP, minIn, maxIn);
				GUI.Label (new Rect (190, 270, 100, 30), "" + FHFWTP.ToString ("#0.000"));
		
				//----------------------------------------------------------
		
				GUI.Label (new Rect (280, 80, 100, 30), "DB 1SB L");
				DB_1SB_L = GUI.HorizontalSlider (new Rect (345, 85, 100, 30), DB_1SB_L, minIn, maxIn);
				GUI.Label (new Rect (460, 80, 100, 30), "" + DB_1SB_L.ToString ("#0.000"));
		
				GUI.Label (new Rect (280, 110, 100, 30), "DB 2SB L");
				DB_2SB_L = GUI.HorizontalSlider (new Rect (345, 115, 100, 30), DB_2SB_L, minIn, maxIn);
				GUI.Label (new Rect (460, 110, 100, 30), "" + DB_2SB.ToString ("#0.000"));
		
				GUI.Label (new Rect (280, 140, 100, 30), "DB 3SB L");
				DB_3SB_L = GUI.HorizontalSlider (new Rect (345, 145, 100, 30), DB_3SB_L, minIn, maxIn);
				GUI.Label (new Rect (460, 140, 100, 30), "" + DB_3SB_L.ToString ("#0.000"));
		
				GUI.Label (new Rect (280, 170, 100, 30), "DB 1SB H");
				DB_1SB_H = GUI.HorizontalSlider (new Rect (345, 175, 100, 30), DB_1SB_H, minIn, maxIn);
				GUI.Label (new Rect (460, 170, 100, 30), "" + DB_1SB_H.ToString ("#0.000"));
		
				GUI.Label (new Rect (280, 200, 100, 30), "DB 2SB H");
				DB_2SB_H = GUI.HorizontalSlider (new Rect (345, 205, 100, 30), DB_2SB_H, minIn, maxIn);
				GUI.Label (new Rect (460, 200, 100, 30), "" + DB_2SB_H.ToString ("#0.000"));
		
				GUI.Label (new Rect (280, 230, 100, 30), "DB 3SB H");
				DB_3SB_H = GUI.HorizontalSlider (new Rect (345, 235, 100, 30), DB_3SB_H, minIn, maxIn);
				GUI.Label (new Rect (460, 230, 100, 30), "" + DB_3SB_H.ToString ("#0.000"));
		
				GUI.Label (new Rect (280, 270, 100, 30), "FWT S");
				FHFWTF = GUI.HorizontalSlider (new Rect (345, 275, 100, 30), FHFWTF, minIn, maxIn);
				GUI.Label (new Rect (460, 270, 100, 30), "" + FHFWTF.ToString ("#0.000"));

				if (GUI.Button (new Rect (410, 480, 70, 30), "Close")) {
						menuSim = false;
				}
				if (GUI.Button (new Rect (20, 480, 70, 30), "Reset")) {
						ResetSim ();
				}

		}
		void ActiveCargo ()
		{

				GUI.Label (new Rect (20, 50, 100, 30), "Trim");
                sldTrim = GUI.HorizontalSlider(new Rect(50, 55, 100, 30), sldTrim, minAngleT, maxAngleT);
				GUI.Label (new Rect (200, 50, 100, 30), "" + sldTrim.ToString ("#0.000"));

				GUI.Label (new Rect (280, 50, 100, 30), "List");
                sldList = GUI.HorizontalSlider(new Rect(310, 55, 100, 30), sldList, minAngleL, maxAngleL);
                GUI.Label(new Rect(460, 50, 100, 30), "" + sldList.ToString("#0.000"));

				//----------------------------------------------------------------------------------------------------
               // editHodl1P = Hold1_1P.ToString();
				GUI.Label (new Rect (20, 80, 100, 30), "Hold1-1P");
                Hold1_1P = GUI.HorizontalSlider(new Rect(80, 85, 100, 30), Hold1_1P, minIn, maxIn);
				GUI.Label (new Rect (200, 80, 100, 30), "" + Hold1_1P.ToString ("#0.000"));

				GUI.Label (new Rect (20, 110, 100, 30), "Hold1-2P");
                Hold1_2P = GUI.HorizontalSlider(new Rect(80, 115, 100, 30), Hold1_2P, minIn, maxIn);
				GUI.Label (new Rect (200, 110, 100, 30), "" + Hold1_2P.ToString ("#0.000"));

				GUI.Label (new Rect (20, 160, 100, 30), "Hold2-1P");
                Hold2_1P = GUI.HorizontalSlider(new Rect(80, 165, 100, 30), Hold2_1P, minIn, maxIn);
				GUI.Label (new Rect (200, 160, 100, 30), "" + Hold2_1P.ToString ("#0.000"));

				GUI.Label (new Rect (20, 190, 100, 30), "Hold2-2P");
                Hold2_2P =  GUI.HorizontalSlider(new Rect(80, 195, 100, 30), Hold2_2P, minIn, maxIn);
				GUI.Label (new Rect (200, 190, 100, 30), "" + Hold2_2P.ToString ("#0.000"));

				GUI.Label (new Rect (20, 240, 100, 30), "Hold3-1P");
                Hold3_1P = GUI.HorizontalSlider(new Rect(80, 245, 100, 30), Hold3_1P, minIn, maxIn);
				GUI.Label (new Rect (200, 240, 100, 30), "" + Hold3_1P.ToString ("#0.000"));

				GUI.Label (new Rect (20, 270, 100, 30), "Hold3-2P");
                Hold3_2P = GUI.HorizontalSlider(new Rect(80, 275, 100, 30), Hold3_2P, minIn, maxIn);
				GUI.Label (new Rect (200, 270, 100, 30), "" + Hold3_2P.ToString ("#0.000"));

				GUI.Label (new Rect (20, 320, 100, 30), "Hold4-1P");
                Hold4_1P =  GUI.HorizontalSlider(new Rect(80, 325, 100, 30), Hold4_1P, minIn, maxIn);
				GUI.Label (new Rect (200, 320, 100, 30), "" + Hold4_1P.ToString ("#0.000"));

				GUI.Label (new Rect (20, 350, 100, 30), "Hold4-2P");
                Hold4_2P = GUI.HorizontalSlider(new Rect(80, 355, 100, 30), Hold4_2P, minIn, maxIn);
				GUI.Label (new Rect (200, 350, 100, 30), "" + Hold4_2P.ToString ("#0.000"));

				//----------------------------------------------------
				GUI.Label (new Rect (280, 80, 100, 30), "Hold1-1SB");
                Hold1_1SB = GUI.HorizontalSlider(new Rect(345, 85, 100, 30), Hold1_1SB, minIn, maxIn);
				GUI.Label (new Rect (460, 80, 100, 30), "" + Hold1_1SB.ToString ("#0.000"));

				GUI.Label (new Rect (280, 110, 100, 30), "Hold1-2SB");
                Hold1_2SB = GUI.HorizontalSlider(new Rect(345, 115, 100, 30), Hold1_2SB, minIn, maxIn);
				GUI.Label (new Rect (460, 110, 100, 30), "" + Hold1_2SB.ToString ("#0.000"));

				GUI.Label (new Rect (280, 160, 100, 30), "Hold2-1SB");
                Hold2_1SB = GUI.HorizontalSlider(new Rect(345, 165, 100, 30), Hold2_1SB, minIn, maxIn);
				GUI.Label (new Rect (460, 160, 100, 30), "" + Hold2_1SB.ToString ("#0.000"));

				GUI.Label (new Rect (280, 190, 100, 30), "Hold2-2SB");
                Hold2_2SB = GUI.HorizontalSlider(new Rect(345, 195, 100, 30), Hold2_2SB, minIn, maxIn);
				GUI.Label (new Rect (460, 190, 100, 30), "" + Hold2_2SB.ToString ("#0.000"));

				GUI.Label (new Rect (280, 240, 100, 30), "Hold3-1SB");
                Hold3_1SB = GUI.HorizontalSlider(new Rect(345, 245, 100, 30), Hold3_1SB, minIn, maxIn);
				GUI.Label (new Rect (460, 240, 100, 30), "" + Hold3_1SB.ToString ("#0.000"));

				GUI.Label (new Rect (280, 270, 100, 30), "Hold3-2SB");
                Hold3_2SB =  GUI.HorizontalSlider(new Rect(345, 275, 100, 30), Hold3_2SB, minIn, maxIn);
				GUI.Label (new Rect (460, 270, 100, 30), "" + Hold3_2SB.ToString ("#0.000"));

				GUI.Label (new Rect (280, 320, 100, 30), "Hold4-1SB");
                Hold4_1SB = GUI.HorizontalSlider(new Rect(345, 325, 100, 30), Hold4_1SB, minIn, maxIn);
				GUI.Label (new Rect (460, 320, 100, 30), "" + Hold4_1SB.ToString ("#0.000"));

				GUI.Label (new Rect (280, 350, 100, 30), "Hold4-2SB");
                Hold4_2SB = GUI.HorizontalSlider(new Rect(345, 355, 100, 30), Hold4_2SB, minIn, maxIn);
				GUI.Label (new Rect (460, 350, 100, 30), "" + Hold4_2SB.ToString ("#0.000"));

                

				//loadContainer();
				//--------------------------------------------------------
       
				if (GUI.Button (new Rect (410, 480, 70, 30), "Close")) {
						menuSim = false;
				}
				if (GUI.Button (new Rect (20, 480, 70, 30), "Reset")) {
						ResetSim ();
				}

		}
		void activeDraft ()
		{

				GUI.Label (new Rect (20, 80, 100, 30), "Draft 1P");
                Draft_1P = GUI.HorizontalSlider(new Rect(80, 85, 100, 30), Draft_1P, minIn, maxIn);
				GUI.Label (new Rect (200, 80, 100, 30), "" + Draft_1P.ToString ("#0.000"));

				GUI.Label (new Rect (20, 110, 100, 30), "Draft 2P");
                Draft_2P = GUI.HorizontalSlider(new Rect(80, 115, 100, 30), Draft_2P, minIn, maxIn);
				GUI.Label (new Rect (200, 110, 100, 30), "" + Draft_2P.ToString ("#0.000"));

				//GUI.Label(new Rect(20, 140, 100, 30), "Draft 3P");
				//Draft_3P = GUI.HorizontalSlider(new Rect(80, 145, 100, 30), Draft_3P, minIn, maxIn);
				//GUI.Label(new Rect(200, 140, 100, 30), "" + Draft_3P.ToString("#0.0"));

				GUI.Label (new Rect (280, 80, 100, 30), " Draft 1SB");
                Draft_1SB = GUI.HorizontalSlider(new Rect(345, 85, 100, 30), Draft_1SB, minIn, maxIn);
				GUI.Label (new Rect (460, 80, 100, 30), "" + Draft_1SB.ToString ("#0.000"));

				GUI.Label (new Rect (280, 110, 100, 30), " Draft 2SB");
                Draft_2SB = GUI.HorizontalSlider(new Rect(345, 115, 100, 30), Draft_2SB, minIn, maxIn);
				GUI.Label (new Rect (460, 110, 100, 30), "" + Draft_2SB.ToString ("#0.000"));

				//GUI.Label(new Rect(280, 140, 100, 30), " Draft 3SB");
				//Draft_3SB = GUI.HorizontalSlider(new Rect(345, 145, 100, 30), Draft_3SB, minIn, maxIn);
				//GUI.Label(new Rect(460, 140, 100, 30), "" + Draft_3SB.ToString("#0.0"));

				if (GUI.Button (new Rect (410, 480, 70, 30), "Close")) {
						menuSim = false;
				}
				if (GUI.Button (new Rect (20, 480, 70, 30), "Reset")) {
						ResetSim ();
				}
		}
		void activeArmForce ()
		{

				GUI.Label (new Rect (20, 80, 100, 30), "AF 1P");
				AF1P = GUI.HorizontalSlider (new Rect (80, 85, 100, 30), AF1P, minIn, maxIn);
				GUI.Label (new Rect (200, 80, 100, 30), "" + AF1P.ToString ("#0.000"));

				GUI.Label (new Rect (20, 110, 100, 30), "AF 2P");
				AF2P = GUI.HorizontalSlider (new Rect (80, 115, 100, 30), AF2P, minIn, maxIn);
				GUI.Label (new Rect (200, 110, 100, 30), "" + AF2P.ToString ("#0.000"));

				GUI.Label (new Rect (280, 80, 100, 30), " AF 1SB");
				AF1SB = GUI.HorizontalSlider (new Rect (345, 85, 100, 30), AF1SB, minIn, maxIn);
				GUI.Label (new Rect (460, 80, 100, 30), "" + AF1SB.ToString ("#0.000"));

				GUI.Label (new Rect (280, 110, 100, 30), " AF 2SB");
				AF2SB = GUI.HorizontalSlider (new Rect (345, 115, 100, 30), AF2SB, minIn, maxIn);
				GUI.Label (new Rect (460, 110, 100, 30), "" + AF2SB.ToString ("#0.000"));


				if (GUI.Button (new Rect (410, 480, 70, 30), "Close")) {
						menuSim = false;
				}
				if (GUI.Button (new Rect (20, 480, 70, 30), "Reset")) {
						ResetSim ();
				}
		}
		void activeAkuarium ()
		{

				GUI.Label (new Rect (20, 80, 100, 30), "lvl Front");
				lvAkuariumF = GUI.HorizontalSlider (new Rect (80, 85, 100, 30), lvAkuariumF, minIn, maxIn);
				GUI.Label (new Rect (200, 80, 100, 30), "" + lvAkuariumF.ToString ("#0.000"));

				GUI.Label (new Rect (20, 110, 100, 30), "lvl Back");
				lvAkuariumB = GUI.HorizontalSlider (new Rect (80, 115, 100, 30), lvAkuariumB, minIn, maxIn);
				GUI.Label (new Rect (200, 110, 100, 30), "" + lvAkuariumB.ToString ("#0.000"));


				if (GUI.Button (new Rect (410, 480, 70, 30), "Close")) {
						menuSim = false;
				}
				if (GUI.Button (new Rect (20, 480, 70, 30), "Reset")) {
						ResetSim ();
				}
		}
		void waterBallastT ()
		{


        //labelDB.active = true;
        doubleBottom[0].SetActive(true);
		doubleBottom [1].SetActive(true);
        doubleBottom [2].SetActive(true);
        doubleBottom [3].SetActive(true);
        doubleBottom [4].SetActive(true);
        doubleBottom [5].SetActive(true);
        doubleBottom [6].SetActive(true);
        doubleBottom [7].SetActive(true);
        doubleBottom [8].SetActive(true);
        doubleBottom [9].SetActive(true);


    }
		void waterBallastF ()
		{

				//labelDB.active = false;
		doubleBottom [0].SetActive(false);
        doubleBottom [1].SetActive(false);
        doubleBottom [2].SetActive(false);
        doubleBottom [3].SetActive(false);
        doubleBottom [4].SetActive(false);
        doubleBottom [5].SetActive(false);
        doubleBottom [6].SetActive(false);
        doubleBottom [7].SetActive(false);
        doubleBottom [8].SetActive(false);
        doubleBottom [9].SetActive(false);

    }
		//---------------------------------------------------
		void formMonitoring (int windowID)
		{

				#region Draft
				GUI.Box (new Rect (20, 30, 500, 25), "Draft");

				GUI.Label (new Rect (20, 60, 150, 30), "Fore Draft Port");
				GUI.TextArea (new Rect (130, 60, 50, 25), "" + D1P .ToString ("F2"));
				GUI.Label (new Rect (180, 60, 150, 30), "m");

				GUI.Label (new Rect (20, 85, 150, 30), "Aft Draft Port");
				GUI.TextArea (new Rect (130, 85, 50, 25), "" + D2P.ToString ("F2"));
				GUI.Label (new Rect (180, 85, 150, 30), "m");

				GUI.Label (new Rect (300, 60, 150, 30), "Fore Draft Starboard");
				GUI.TextArea (new Rect (440, 60, 50, 25), "" + D1S.ToString ("F2"));
				GUI.Label (new Rect (490, 60, 150, 30), "m");

				GUI.Label (new Rect (300, 85, 150, 30), "Aft Draft Starboard");
				GUI.TextArea (new Rect (440, 85, 50, 25), "" + D2S.ToString ("F2"));
				GUI.Label (new Rect (490, 85, 150, 30), "m");

				#endregion

				#region Angle
				GUI.Box (new Rect (20, 120, 500, 25), "Angle");

				GUI.Label (new Rect (20, 150, 150, 30), "Trim Angle");
				//GUI.TextArea (new Rect (130, 150, 50, 25), "" + Konv_Sudut (sldTrim-0.071f).ToString ("F2"));
                GUI.TextArea(new Rect(130, 150, 50, 25), "" + dTrimVal.ToString("F2"));
				GUI.Label (new Rect (180, 150, 150, 30), "deg");

				GUI.Label (new Rect (20, 175, 150, 30), "List Angle");
				//GUI.TextArea (new Rect (130, 175, 50, 25), "" + (Konv_Sudut (sldList) * -1).ToString ("F2"));
                GUI.TextArea(new Rect(130, 175, 50, 25), "" + dHeelVal.ToString("F2"));
				GUI.Label (new Rect (180, 175, 150, 30), "deg");

				GUI.Label (new Rect (300, 150, 150, 30), "Diff Trim");
				GUI.TextArea (new Rect (440, 150, 50, 25), "" + mmToM(TrimVal) .ToString ("F2"));
				GUI.Label (new Rect (490, 150, 150, 30), "m");

				GUI.Label (new Rect (300, 175, 150, 30), "Diff List");
				GUI.TextArea (new Rect (440, 175, 50, 25), "" + mmToM(ListVal).ToString ("F2"));
				GUI.Label (new Rect (490, 175, 150, 30), "m");

				#endregion

				#region Arm Force
                GUI.Box(new Rect(20, 210, 500, 25), "Arm Force");

                GUI.Label(new Rect(20, 240, 150, 30), "AF Port 1");
                GUI.TextArea(new Rect(130, 240, 50, 25), "" + ForeP(AF1P).ToString("F2"));
                GUI.Label(new Rect(180, 240, 150, 30), "kgf");

                GUI.TextArea(new Rect(200, 240, 50, 25), "" + (KgtoTon(ForeP(AF1P))).ToString("F2"));
                GUI.Label(new Rect(250, 240, 150, 30), "ton");

                GUI.Label(new Rect(20, 265, 150, 30), "AF Port 2");
                GUI.TextArea(new Rect(130, 265, 50, 25), "" + AftP(AF2P).ToString("F2"));
                GUI.Label(new Rect(180, 265, 150, 30), "kgf");

                GUI.TextArea(new Rect(200, 265, 50, 25), "" + (KgtoTon(AftP(AF2P))).ToString("F2"));
                GUI.Label(new Rect(250, 265, 150, 30), "ton");

                GUI.Label(new Rect(20, 290, 150, 30), "AF SB 1");
                GUI.TextArea(new Rect(130, 290, 50, 25), "" + ForeSB(AF1SB).ToString("F2"));
                GUI.Label(new Rect(180, 290, 150, 30), "kgf");

                GUI.TextArea(new Rect(200, 290, 50, 25), "" + (KgtoTon(ForeSB(AF1SB))).ToString("F2"));
                GUI.Label(new Rect(250, 290, 150, 30), "ton");

                GUI.Label(new Rect(20, 310, 150, 30), "AF SB 2");
                GUI.TextArea(new Rect(130, 310, 50, 25), "" + AftP(AF2SB).ToString("F2"));
                GUI.Label(new Rect(180, 310, 150, 30), "kgf");

                GUI.TextArea(new Rect(200, 310, 50, 25), "" + (KgtoTon(AftP(AF2SB))).ToString("F2"));
                GUI.Label(new Rect(250, 310, 150, 30), "ton");

				#endregion

                //#region Aquarium Water Level
                //GUI.Box (new Rect (20, 300, 500, 25), "Aquarium Water Level");

                //GUI.Label (new Rect (20, 330, 150, 30), "Level Front");
                //GUI.TextArea (new Rect (130, 330, 50, 25), "" + (LeveleTapeDepan (lvAkuariumF)).ToString ("F2"));
                //GUI.Label (new Rect (180, 330, 150, 30), "cm");

                //GUI.Label (new Rect (300, 330, 150, 30), "Level Back");
                //GUI.TextArea (new Rect (440, 330, 50, 25), "" + (LeveleTapeBelakang (lvAkuariumB)).ToString ("F2"));
                //GUI.Label (new Rect (490, 330, 150, 30), "cm");

                //#endregion

				#region Cargo Compartement
                GUI.Box(new Rect(20, 370, 500, 25), "Cargo Compartement");

                GUI.Label(new Rect(20, 400, 150, 30), "HOLD 1");
                GUI.TextArea(new Rect(130, 400, 50, 25), "" + (F1 / 1000).ToString("F1"));
                GUI.Label(new Rect(180, 400, 150, 30), "kg");
                GUI.TextArea(new Rect(200, 400, 50, 25), "" + (KgtoTon(F1 / 1000)).ToString("F1"));
                GUI.Label(new Rect(250, 400, 150, 30), "ton");

                GUI.Label(new Rect(20, 430, 150, 30), "HOLD 2");
                GUI.TextArea(new Rect(130, 430, 50, 25), "" + (F2 / 1000).ToString("F1"));
                GUI.Label(new Rect(180, 430, 150, 30), "kg");
                GUI.TextArea(new Rect(200, 430, 50, 25), "" + (KgtoTon(F2 / 1000)).ToString("F1"));
                GUI.Label(new Rect(250, 430, 150, 30), "ton");

                GUI.Label(new Rect(20, 460, 150, 30), "HOLD 3");
                GUI.TextArea(new Rect(130, 460, 50, 25), "" + (F3 / 1000).ToString("F1"));
                GUI.Label(new Rect(180, 460, 150, 30), "kg");
                GUI.TextArea(new Rect(200, 460, 50, 25), "" + (KgtoTon(F3 / 1000)).ToString("F1"));
                GUI.Label(new Rect(250, 460, 150, 30), "ton");

                GUI.Label(new Rect(20, 490, 150, 30), "HOLD 4");
                GUI.TextArea(new Rect(130, 490, 50, 25), "" + (F4 / 1000).ToString("F1"));
                GUI.Label(new Rect(180, 490, 150, 30), "kg");
                GUI.TextArea(new Rect(200, 490, 50, 25), "" + (KgtoTon(F4 / 1000)).ToString("F1"));
                GUI.Label(new Rect(250, 490, 150, 30), "ton");

				#endregion

				#region Ballast Tank
				GUI.Box (new Rect (20, 535, 500, 25), "Ballast Tank");
		
				GUI.Label (new Rect (20, 565, 150, 30), "Fore Peak Tank");
				GUI.TextArea (new Rect (130, 565, 50, 25), "" + FCAB.ToString ("F2"));
		
				GUI.Label (new Rect (20, 590, 150, 20), "Double Bottom 1P");
				GUI.TextArea (new Rect (130, 590, 50, 20), "" + DB_1P.ToString ("F2"));
				GUI.Label (new Rect (20, 610, 150, 20), "Double Bottom 2P");
				GUI.TextArea (new Rect (130, 610, 50, 20), "" + DB_2P.ToString ("F2"));
				GUI.Label (new Rect (20, 630, 150, 20), "Double Bottom 3P");
				GUI.TextArea (new Rect (130, 630, 50, 20), "" + DB_3P.ToString ("F2"));
				GUI.Label (new Rect (20, 650, 150, 20), "FWT Port");
				GUI.TextArea (new Rect (130, 650, 50, 20), "" + FHFWTP.ToString ("F2"));
		
				//GUI.Label(new Rect(20, 675, 150, 20), "Side Tank 1P");
				//GUI.TextArea(new Rect(130, 675, 50, 20), "" + ST_1P.ToString("F2"));
				//GUI.Label(new Rect(20, 695, 150, 20), "Side Tank 2P");
				//GUI.TextArea(new Rect(130, 695, 50, 20), "" + ST_2P.ToString("F2"));
				//GUI.Label(new Rect(20, 715, 150, 20), "Side Tank 3P");
				//GUI.TextArea(new Rect(130, 715, 50, 20), "" + ST_3P.ToString("F2"));
				//GUI.Label(new Rect(20, 735, 150, 20), "Side Tank 4P");
				//GUI.TextArea(new Rect(130, 735, 50, 20), "" + ST_4P.ToString("F2"));
		
		
		
				GUI.Label (new Rect (300, 565, 150, 30), "Single DB");
				GUI.TextArea (new Rect (440, 565, 50, 25), "" + FCFB.ToString ("F2"));
		
				GUI.Label (new Rect (300, 590, 150, 20), "Double Bottom 1SB");
				GUI.TextArea (new Rect (440, 590, 50, 20), "" + DB_1SB.ToString ("F2"));
				GUI.Label (new Rect (300, 610, 150, 20), "Double Bottom 2SB");
				GUI.TextArea (new Rect (440, 610, 50, 20), "" + DB_2SB.ToString ("F2"));
				GUI.Label (new Rect (300, 630, 150, 20), "Double Bottom 3SB");
				GUI.TextArea (new Rect (440, 630, 50, 20), "" + DB_3SB.ToString ("F2"));
				GUI.Label (new Rect (300, 650, 150, 20), "FWT Port SB");
				GUI.TextArea (new Rect (440, 650, 50, 20), "" + FHFWTF.ToString ("F2"));
		
				//GUI.Label(new Rect(300, 675, 150, 20), "Side Tank 1SB");
				//GUI.TextArea(new Rect(440, 675, 50, 20), "" + ST_1SB.ToString("F2"));
				//GUI.Label(new Rect(300, 695, 150, 20), "Side Tank 2SB");
				//GUI.TextArea(new Rect(440, 695, 50, 20), "" + ST_2SB.ToString("F2"));
				//GUI.Label(new Rect(300, 715, 150, 20), "Side Tank 3SB");
				//GUI.TextArea(new Rect(440, 715, 50, 20), "" + ST_3SB.ToString("F2"));
				//GUI.Label(new Rect(300, 735, 150, 20), "Side Tank 4SB");
				//GUI.TextArea(new Rect(440, 735, 50, 20), "" + ST_4SB.ToString("F2"));
		
		
				#endregion

				GUI.DragWindow ();

		}

		void formBRT (int windowID)
        {
            #region old GUI
            GUI.Box(new Rect(20, 80, 400, 100), "Info : " + message);

            GUI.Label(new Rect(20, 30, 50, 30), "Bay");
            if (GUI.Button(new Rect(50, 30, 30, 30), selectedBay))
            {
                editingA = true;
            }

            if (editingA)
            {

                for (int b = 0; b < itemBay.Length; b++)
                {
                    if (GUI.Button(new Rect(50, (30 * b) + 60, 30, 30), itemBay[b]))
                    {
                        selectedBay = itemBay[b];
                        editingA = false;
                    }
                }
            }


            GUI.Label(new Rect(100, 30, 50, 30), "Row");
            if (GUI.Button(new Rect(130, 30, 30, 30), selectedRow))
            {
                editingB = true;
            }

            if (editingB)
            {

                for (int r = 0; r < itemRow.Length; r++)
                {
                    if (GUI.Button(new Rect(130, (30 * r) + 60, 30, 30), itemRow[r]))
                    {
                        selectedRow = itemRow[r];
                        editingB = false;
                    }
                }
            }

            GUI.Label(new Rect(180, 30, 50, 30), "Teir");
            sldTier = GUI.HorizontalSlider(new Rect(210, 35, 100, 30), Mathf.Ceil(sldTier), minTier, maxTier);
            GUI.Label(new Rect(320, 30, 100, 30), "" + sldTier.ToString("#0"));

            #endregion

               

                if (GUI.Button(new Rect(280, 250, 80, 30), "Load"))
                {
                    #region Bay 15
                    if (selectedBay == "15" && selectedRow == "03")
                    {
                      

                       // iBay15Row3 += 1;

                        iBay15Row3 += (int)sldTier;
                        if (iBay15Row3 > 5){ iBay15Row3 = 0;}
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "15" && selectedRow == "01")
                    {
                        iBay15Row1 += (int)sldTier;
                        if (iBay15Row1 > 5) { iBay15Row1 = 0; }
                        CalculateContainerCG_Orientation();
                        loadStack();

                    }
                    else if (selectedBay == "15" && selectedRow == "00")
                    {
                        iBay15Row0 += (int)sldTier;
                        if (iBay15Row0 > 5) { iBay15Row0 = 0; }
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "15" && selectedRow == "02")
                    {
                        iBay15Row2 += (int)sldTier;
                        if (iBay15Row2 > 5) { iBay15Row2 = 0; }
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "15" && selectedRow == "04")
                    {
                        iBay15Row4 += (int)sldTier;
                        if (iBay15Row4 > 5) { iBay15Row4 = 0; }
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }

                    #endregion

                    #region Bay 13
                    if (selectedBay == "13" && selectedRow == "03")
                    {
                        iBay13Row3 += (int)sldTier;
                        if (iBay13Row3 > 5) { iBay13Row3 = 0; }
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "13" && selectedRow == "01")
                    {
                        iBay13Row1 += (int)sldTier;
                        CalculateContainerCG_Orientation();
                        if (iBay13Row1 > 5) { iBay13Row1 = 0; }
                        loadStack();
                    }
                    else if (selectedBay == "13" && selectedRow == "00")
                    {
                        iBay13Row0 += (int)sldTier;
                        if (iBay13Row0 > 5) { iBay13Row0 = 0; }
                     
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "13" && selectedRow == "02")
                    {
                        iBay13Row2 += (int)sldTier;
                        if (iBay13Row2 > 5) { iBay13Row2 = 0; }
                      
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "13" && selectedRow == "04")
                    {
                        iBay13Row4 += (int)sldTier;
                        if (iBay13Row4 > 5) { iBay13Row4 = 0; }
                       
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }

                    #endregion

                    #region Bay 11
                    if (selectedBay == "11" && selectedRow == "03")
                    {
                        iBay11Row3 += (int)sldTier;
                        if (iBay11Row3 > 5) { iBay11Row3 = 0; }
                     
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "11" && selectedRow == "01")
                    {
                        iBay11Row1 += (int)sldTier;
                        if (iBay11Row1 > 5) { iBay11Row1 = 0; }
                      
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "11" && selectedRow == "00")
                    {
                        iBay11Row0 += (int)sldTier;
                        if (iBay11Row0 > 5) { iBay11Row0 = 0; }
                       
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "11" && selectedRow == "02")
                    {
                        iBay11Row2 += (int)sldTier;
                        if (iBay11Row2 > 5) { iBay11Row2 = 0; }
                       
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "11" && selectedRow == "04")
                    {
                        iBay11Row4 += (int)sldTier;
                        if (iBay11Row4 > 5) { iBay11Row4 = 0; }
                     
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }

                    #endregion

                    #region Bay 9
                    if (selectedBay == "09" && selectedRow == "03")
                    {
                        iBay9Row3 += (int)sldTier;
                        if (iBay9Row3 > 5) { iBay9Row3 = 0; }
                       
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "09" && selectedRow == "01")
                    {
                        iBay9Row1 += (int)sldTier;
                        if (iBay9Row1 > 5) { iBay9Row1 = 0; }
                       
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "09" && selectedRow == "00")
                    {
                        iBay9Row0 += (int)sldTier;
                        if (iBay9Row0 > 5) { iBay9Row0 = 0; }
                     
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "09" && selectedRow == "02")
                    {
                        iBay9Row2 += (int)sldTier;
                        if (iBay9Row2 > 5) { iBay9Row2 = 0; }
                     
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "09" && selectedRow == "04")
                    {
                        iBay9Row4 += (int)sldTier;
                        if (iBay9Row4 > 5) { iBay9Row4 = 0; }
                    
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }

                    #endregion

                    #region Bay 7
                    if (selectedBay == "07" && selectedRow == "03")
                    {
                        iBay7Row3 += (int)sldTier;
                        if (iBay7Row3 > 5) { iBay7Row3 = 0; }
                     
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "07" && selectedRow == "01")
                    {
                        iBay7Row1 += (int)sldTier;
                        if (iBay7Row1 > 5) { iBay7Row1 = 0; }
                    
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "07" && selectedRow == "00")
                    {
                        iBay7Row0 += (int)sldTier;
                        if (iBay7Row0 > 5) { iBay7Row0 = 0; }
                     
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "07" && selectedRow == "02")
                    {
                        iBay7Row2 += (int)sldTier;
                        if (iBay7Row2 > 5) { iBay7Row2 = 0; }
                       
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "07" && selectedRow == "04")
                    {
                        iBay7Row4 += (int)sldTier;
                        if (iBay7Row4 > 5) { iBay7Row4 = 0; }
                      
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }

                    #endregion

                    #region Bay 5
                    if (selectedBay == "05" && selectedRow == "03")
                    {
                        iBay5Row3 += (int)sldTier;
                        if (iBay5Row3 > 5) { iBay5Row3 = 0; }
                     
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "05" && selectedRow == "01")
                    {
                        iBay5Row1 += (int)sldTier;
                        if (iBay5Row1 > 5) { iBay5Row1 = 0; }
                       
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "05" && selectedRow == "00")
                    {
                        iBay5Row0 += (int)sldTier;
                        if (iBay5Row0 > 5) { iBay5Row0 = 0; }
                        
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "05" && selectedRow == "02")
                    {
                        iBay5Row2 += (int)sldTier;
                        if (iBay5Row2 > 5) { iBay5Row2 = 0; }
                        
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "05" && selectedRow == "04")
                    {
                        iBay5Row4 += (int)sldTier;
                        if (iBay5Row4 > 5) { iBay5Row4 = 0; }
                    
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }

                    #endregion

                    #region Bay 3
                    if (selectedBay == "03" && selectedRow == "03")
                    {
                        iBay3Row3 += (int)sldTier;
                        if (iBay3Row3 > 3) { iBay3Row3 = 0; }
                      
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "03" && selectedRow == "01")
                    {
                        iBay3Row1 += (int)sldTier;
                        if (iBay3Row1 > 3) { iBay3Row1 = 0; }
                     
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "03" && selectedRow == "00")
                    {
                        iBay3Row0 += (int)sldTier;
                        if (iBay3Row0 > 3) { iBay3Row0 = 0; }
                     
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "03" && selectedRow == "02")
                    {
                        iBay3Row2 += (int)sldTier;
                        if (iBay3Row2 > 3) { iBay3Row2 = 0; }
            
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "03" && selectedRow == "04")
                    {
                        iBay3Row4 += (int)sldTier;
                        if (iBay3Row4 > 3) { iBay3Row4 = 0; }
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }

                    #endregion

                    #region Bay 1
                    if (selectedBay == "01" && selectedRow == "01")
                    {
                        iBay1Row1 += (int)sldTier;
                        if (iBay1Row1 > 5) { iBay1Row1 = 0; }
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "01" && selectedRow == "00")
                    {
                        iBay1Row0 += (int)sldTier;
                        if (iBay1Row0 > 5) { iBay1Row0 = 0; }
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    else if (selectedBay == "01" && selectedRow == "02")
                    {
                        iBay1Row2 += (int)sldTier;
                        if (iBay1Row2 > 5) { iBay1Row2 = 0; }
                        CalculateContainerCG_Orientation();
                        loadStack();
                    }
                    

                    #endregion

                }

                    #region old
                    //  if (BobotTotal >= 30400)
                  //  {
                  //      print("cannot loading");
                  //  }
                    
                  //          if (selectedBay == "01" && BobotTotal == 2400)
                  //          {
                  //              if (selectedRow == "04" && selectedRow == "03")
                  //              {
                  //                  print("cannot loading");
                  //              }
                  //          }
                          
                        
                  //  else
                  //  {
                  //      print("loading");
                  //      loadStack();
                  //      BobotTotal = BobotTotal + m_contLama;
                  //      jumCon = jumCon + jStack;
                  //      tmpPosBay = tmpPosBay + mPosBay;
                  //      tmpPosRow = tmpPosRow + mPosRow;
                  //      tmpPosTier = tmpPosTier + mPosTier;

                  //      momentTBay = tmpPosBay / 100;
                  //      momentTRow = tmpPosRow / 100;
                  //      momentTTier = tmpPosTier / 100;
                        
                  //      //BobotTotal = BobotTotal + m_contLama;
                  //      //jumCon = jumCon + jStack;
                  //      //tmpPosBay = tmpPosBay + mPosBay;
                  //      //tmpPosRow = tmpPosRow + mPosRow;
                  //      //tmpPosTier = tmpPosTier + mPosTier;

                  //      //PosisiMuatan();
                  //      shipVessel.transform.position = new Vector3(0, -5.177296f - dDraftVal / 20, 0);
                  //      print("draft akhir: " + (-5.177296f - dDraftVal / 20));

                        

                  //  }
                   
                           
                  //        // jumCon = 0;

                           

                  //// print("total Posbay ;" + tmpPosBay.ToString());


                  // //print("total muatan baru :" + BobotTotal);
                    // //print("Jumlah peti kemas :" + jumCon);
                    #endregion


                


                
				if (GUI.Button (new Rect (360, 250, 80, 30), "Reset")) {


			        dischargeBRT();
                    _JumCon = 0;
                    dDispVal = 0;
                    dHeelVal = 0;
                    dTrimVal = 0;
                    sldTier = 0;
                    Gmx = 0;
                    Gmy = 0;
                    xCGTotalLoad = 0;


				}
				

				//GUI.DragWindow ();



		}

		void formSimulasi (int windowID)  //----------form simulasi
		{

				if (GUI.Button (new Rect (20, 20, 100, 30), "Cargo Hold")) {
						tabBallast = false;
						//lblSideTank.active = false;
						tabTrimHold = true;
						tabDraft = false;
						tabAF = false;
						tabLvAqua = false;
						//waterBallastF();
				}
				if (tabTrimHold) {
						ActiveCargo ();
						waterBallastF ();
						doubleBottom [10].GetComponent<Renderer>().enabled = true;

						//waterTankT();
						//lblCargoTank.active = true;
				}

				if (GUI.Button (new Rect (120, 20, 100, 30), "Ballast Tank")) {
						//lblCargoTank.active = false;
						tabTrimHold = false;
						tabDraft = false;
						tabBallast = true;
						tabAF = false;
						tabLvAqua = false;
           
						//waterTankF();
						//lblSideTank.active = true;

				}
				if (tabBallast) {
						activeBallastTank ();
						waterBallastT ();
						doubleBottom [10].GetComponent<Renderer>().enabled = false;
           
				}


				if (GUI.Button (new Rect (220, 20, 100, 30), "Draft")) {
						tabTrimHold = false;
						tabBallast = false;
						tabDraft = true;
						tabAF = false;
						tabLvAqua = false;
            
				}

				if (tabDraft) {
						activeDraft ();
						print ("view ballast");
				}

				if (GUI.Button (new Rect (320, 20, 100, 30), "Arm Force")) {
						tabTrimHold = false;
						tabBallast = false;
						tabDraft = false;
						tabAF = true;
						tabLvAqua = false;

				}
				if (tabAF) {
						activeArmForce ();

				}
				if (GUI.Button (new Rect (420, 20, 100, 30), "lvl Akuarium")) {
						tabTrimHold = false;
						tabBallast = false;
						tabDraft = false;
						tabAF = false;
						tabLvAqua = true;
				}
				if (tabLvAqua) {
						activeAkuarium ();
				}
				GUI.DragWindow ();

		}

        void formExit(int windowID)
        {

            if (GUI.Button(new Rect(10, 30, 100, 40), "Yes"))
            {
                data.OnApplicationQuit();
                Application.Quit();
                print("Keluar");
            }
            if (GUI.Button(new Rect(120, 30, 100, 40), "No"))
            {
                menuExit = false;
                print("no");
            }
            GUI.DragWindow();

        }

		void formMode (int windowID)
		{


				if (GUI.Button (new Rect (10, 25, 100, 50), "Solid")) {
						modeNormal ();
						print ("Normal");
				}

				if (GUI.Button (new Rect (120, 25, 100, 50), "Transparant")) {
						modeTransparan ();
						print ("Transparan");
				}

				GUI.DragWindow ();

		}
        void ResetSim()
        {

            sldTrim = 2.5f;
            sldList = 2.5f;


            //--------------HOLD for sensor	input
            Hold1_1P = 0.0f;
            Hold1_2P = 0.0f;
            Hold2_1P = 0.0f;
            Hold2_2P = 0.0f;
            Hold3_1P = 0.0f;
            Hold3_2P = 0.0f;
            Hold4_1P = 0.0f;
            Hold4_2P = 0.0f;
            //Hold5_1P = 0.0f;
            //Hold5_2P = 0.0f;
            Hold1_1SB = 0.0f;
            Hold1_2SB = 0.0f;
            Hold2_1SB = 0.0f;
            Hold2_2SB = 0.0f;
            Hold3_1SB = 0.0f;
            Hold3_2SB = 0.0f;
            Hold4_1SB = 0.0f;
            Hold4_2SB = 0.0f;
            //Hold5_1SB = 0.0f;
            //Hold5_2SB = 0.0f;



        }

	public void ModeKapal()
	{


		ModeMaterial = !ModeMaterial;

	}

	void modeTransparan()
	{

        //if (ModeMaterial)
        //{
        shipMode.transform.gameObject.GetComponent<Renderer>().material = shader2;
        //}
        //laut.active = false;
        //pointLCG.active = true;
        // pointCF.active = true;
        // pointCB.active = true;

        waterBallastF();

		//  obj_Terrain.transform.active = false;
		// water.transform.active = false;
	}

		void modeNormal()
        {
            shipMode.transform.gameObject.GetComponent<Renderer>().material = shader1;
            //laut.active = true;
            //pointLCG.active = false;
            // pointCF.active = false;
            // pointCB.active = false;

            waterBallastF();
            //obj_Terrain.transform.active = true;
            //water.transform.active = true;

        }
    #endregion


        #region CG muatan berdasarkan sensor 20150830

        public void PosBebanTray1()
        {

            VoltPort1 = Hold1_1P + Hold1_2P;
            VoltPort1 -= 0.089f;

            if (VoltPort1 < 0) { VoltPort1 = 0; }

            float VoltStar1 = Hold1_1SB + Hold1_2SB;
            VoltStar1 = VoltStar1 - 0.371f;

            if (VoltStar1 < 0) { VoltStar1 = 0; }

            Moment_Tray1 = 97.5f * VoltPort1 - 97.5f * VoltStar1;

            float tVoltPS = VoltPort1+VoltStar1;

            if (tVoltPS > 0)
            {
            GLoad_Tray1 = Moment_Tray1 / (VoltPort1 + VoltStar1);
            }else{
                GLoad_Tray1 = 0;
            }

            print("moment T1 :" + Moment_Tray1.ToString("F2"));
            print("G Load T1 :" + GLoad_Tray1.ToString("F2"));
        }

        public void PosBebanTray2()
        {

            float VoltPort2 = Hold2_1P + Hold2_2P;
            VoltPort2 -= 0.118f;

            if (VoltPort2 < 0) { VoltPort2 = 0; }

            float VoltStar2 = Hold2_1SB + Hold2_2SB;
            VoltStar2 = VoltStar2 - 0.186f;


            if (VoltStar2 < 0) { VoltPort2 = 0; }

            float tVoltPS = VoltPort2 + VoltStar2;

           
            Moment_Tray2 = 97.5f * VoltPort2 - 97.5f * VoltStar2;

            if (tVoltPS > 0)
            {
                GLoad_Tray2 = Moment_Tray2 / (VoltPort2 + VoltStar2);
            }
            else
            {
                GLoad_Tray2 = 0;
            }

           


        }

        public void PosBebanTray3()
        {

            float VoltPort3 = Hold3_1P + Hold3_2P;
            VoltPort3 -= 0.411f;

            if (VoltPort3 < 0) { VoltPort3 = 0; }

            float VoltStar3 = Hold3_1SB + Hold3_2SB;
            VoltStar3 = VoltStar3 - 0.23f;


            if (VoltStar3 < 0) { VoltPort3 = 0; }

            float tVoltPS = VoltPort3 + VoltStar3;


            Moment_Tray3 = 97.5f * VoltPort3 - 97.5f * VoltStar3;

            if (tVoltPS > 0)
            {
                GLoad_Tray3 = Moment_Tray3 / (VoltPort3 + VoltStar3);
            }
            else
            {
                GLoad_Tray3 = 0;
            }

        }

        public void PosBebanTray4()
        {

            float VoltPort4 = Hold4_1P + Hold4_2P;
            VoltPort4 -= 0.411f;

            if (VoltPort4 < 0) { VoltPort4 = 0; }

            float VoltStar4 = Hold4_1SB + Hold4_2SB;
            VoltStar4 = VoltStar4 - 0.23f;

            if (VoltStar4 < 0) { VoltPort4 = 0; }

            float tVoltPS = VoltPort4 + VoltStar4;


            Moment_Tray4 = 97.5f * VoltPort4 - 97.5f * VoltStar4;

            if (tVoltPS > 0)
            {
                GLoad_Tray4 = Moment_Tray4 / (VoltPort4 + VoltStar4);
            }
            else
            {
                GLoad_Tray4 = 0;
            }



        }



        #endregion

        #region Container load data, position and cg

        int iBay15Row3 = 0; // number of tier
        int iBay15Row1 = 0; // number of tier
        int iBay15Row0 = 0; // number of tier
        int iBay15Row2 = 0; // number of tier
        int iBay15Row4 = 0; // number of tier
        int iBay13Row3 = 0; // number of tier
        int iBay13Row1 = 0; // number of tier
        int iBay13Row0 = 0; // number of tier
        int iBay13Row2 = 0; // number of tier
        int iBay13Row4 = 0; // number of tier
        int iBay11Row3 = 0; // number of tier
        int iBay11Row1 = 0; // number of tier
        int iBay11Row0 = 0; // number of tier
        int iBay11Row2 = 0; // number of tier
        int iBay11Row4 = 0; // number of tier
        int iBay9Row3 = 0; // number of tier
        int iBay9Row1 = 0; // number of tier
        int iBay9Row0 = 0; // number of tier
        int iBay9Row2 = 0; // number of tier
        int iBay9Row4 = 0; // number of tier
        int iBay7Row3 = 0; // number of tier
        int iBay7Row1 = 0; // number of tier
        int iBay7Row0 = 0; // number of tier
        int iBay7Row2 = 0; // number of tier
        int iBay7Row4 = 0; // number of tier
        int iBay5Row3 = 0; // number of tier
        int iBay5Row1 = 0; // number of tier
        int iBay5Row0 = 0; // number of tier
        int iBay5Row2 = 0; // number of tier
        int iBay5Row4 = 0; // number of tier
        int iBay3Row3 = 0; // number of tier
        int iBay3Row1 = 0; // number of tier
        int iBay3Row0 = 0; // number of tier
        int iBay3Row2 = 0; // number of tier
        int iBay3Row4 = 0; // number of tier
        int iBay1Row1 = 0; // number of tier
        int iBay1Row0 = 0; // number of tier
        int iBay1Row2 = 0; // number of tier

        public int iLoadCount = 0; // total number of container loads

        public float dWeightLightShip = 29;
        public float dWeightTotalLoad = 0;
        public float dWeightTotalShip = 0;

        float tempDheel;

        public float xCGLightShip;
        public float yCGLightShip;
        public float zCGLightShip;

        public float xCGTotalLoad;
        public float yCGTotalLoad;
        public float zCGTotalLoad;

        public float xCGTotalShip;
        public float yCGTotalShip;
        public float zCGTotalShip;

        public float tempDisp;

        // lookup table data : iLoadData(row, column), Container Tier data at given bay and row
        // lookup table data : xLoadData(row, column), Container cg_x data at given bay and row
        // lookup table data : yLoadData(row, column), Container cg_y data at given bay and row
        // lookup table data : zLoadData(row, column), Container cg_z data at given bay and row
        // row   = row position, left to righ = 3, 1, 0, 2, 4
        // colum = bay position, aft to front = 15, 13, 11, 9, 7, 5, 3, 1
        int[,] iLoadDataTable2D = new int[5, 8];
        float[,] xLoadDataTable2D = new float[5, 8] {
            {-443.9f,	-323.9f,	-115.6f,	4.4f,	135.4f,	255.4f,	469.1f,	0.0f},
            {-443.9f,	-323.9f,	-115.6f,	4.4f,	135.4f,	255.4f,	469.1f,	589.1f},
            {-443.9f,	-323.9f,	-115.6f,	4.4f,	135.4f,	255.4f,	469.1f,	589.1f},
            {-443.9f,	-323.9f,	-115.6f,	4.4f,	135.4f,	255.4f,	469.1f,	589.1f},
            {-443.9f,	-323.9f,	-115.6f,	4.4f,	135.4f,	255.4f,	469.1f,	0.0f}
        };
        float[,] yLoadDataTable2D = new float[5, 8] {
            {97.5f,	97.5f,	97.5f,	97.5f,	97.5f,	97.5f,	97.5f,	0f},
            {48.5f,	48.5f,	48.5f,	48.5f,	48.5f,	48.5f,	48.5f,	48.5f},
            {0.0f,	0.0f,	0.0f,	0.0f,	0.0f,	0f,	0.0f,	0.0f},
            {-48.5f,	-48.5f,	-48.5f,	-48.5f,	-48.5f,	-48.5f,	-48.5f,	-48.5f},
            {-97.5f,	-97.5f,	-97.5f,	-97.5f,	-97.5f,	-97.5f,	-97.5f,	0.0f}
        };
        float[,] zLoadDataTable2D = new float[5, 8] {
            {44f,	44f,	44f,	44f,	44f,	44f,	64f,	0.0f},
            {44f,	44f,	44f,	44f,	44f,	44f,	64f,	64f},
            {44f,	44f,	44f,	44f,	44f,	44f,	64f,	64f},
            {44f,	44f,	44f,	44f,	44f,	44f,	64f,	64f},
            {44f,	44f,	44f,	44f,	44f,	44f,	64f,	0.0f}
        };

        private void CalculateContainerCG_Orientation()
        {
            iLoadDataTable2D[0, 0] = iBay15Row3;
            iLoadDataTable2D[1, 0] = iBay15Row1;
            iLoadDataTable2D[2, 0] = iBay15Row0;
            iLoadDataTable2D[3, 0] = iBay15Row2;
            iLoadDataTable2D[4, 0] = iBay15Row4;

            iLoadDataTable2D[0, 1] = iBay13Row3;
            iLoadDataTable2D[1, 1] = iBay13Row1;
            iLoadDataTable2D[2, 1] = iBay13Row0;
            iLoadDataTable2D[3, 1] = iBay13Row2;
            iLoadDataTable2D[4, 1] = iBay13Row4;

            iLoadDataTable2D[0, 2] = iBay11Row3;
            iLoadDataTable2D[1, 2] = iBay11Row1;
            iLoadDataTable2D[2, 2] = iBay11Row0;
            iLoadDataTable2D[3, 2] = iBay11Row2;
            iLoadDataTable2D[4, 2] = iBay11Row4;

            iLoadDataTable2D[0, 3] = iBay9Row3;
            iLoadDataTable2D[1, 3] = iBay9Row1;
            iLoadDataTable2D[2, 3] = iBay9Row0;
            iLoadDataTable2D[3, 3] = iBay9Row2;
            iLoadDataTable2D[4, 3] = iBay9Row4;

            iLoadDataTable2D[0, 4] = iBay7Row3;
            iLoadDataTable2D[1, 4] = iBay7Row1;
            iLoadDataTable2D[2, 4] = iBay7Row0;
            iLoadDataTable2D[3, 4] = iBay7Row2;
            iLoadDataTable2D[4, 4] = iBay7Row4;

            iLoadDataTable2D[0, 5] = iBay5Row3;
            iLoadDataTable2D[1, 5] = iBay5Row1;
            iLoadDataTable2D[2, 5] = iBay5Row0;
            iLoadDataTable2D[3, 5] = iBay5Row2;
            iLoadDataTable2D[4, 5] = iBay5Row4;

            iLoadDataTable2D[0, 6] = iBay3Row3;
            iLoadDataTable2D[1, 6] = iBay3Row1;
            iLoadDataTable2D[2, 6] = iBay3Row0;
            iLoadDataTable2D[3, 6] = iBay3Row2;
            iLoadDataTable2D[4, 6] = iBay3Row4;

            iLoadDataTable2D[0, 7] = 0;
            iLoadDataTable2D[1, 7] = iBay1Row1;
            iLoadDataTable2D[2, 7] = iBay1Row0;
            iLoadDataTable2D[3, 7] = iBay1Row2;
            iLoadDataTable2D[4, 7] = 0;

            xCGLightShip = 0;
            yCGLightShip = 0;
            zCGLightShip = KG_GC_REAL;

            xCGTotalLoad = 0;
            xCGTotalLoad = 0;
            xCGTotalLoad = 0;

            iLoadCount = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 8; j++)
                {
                    iLoadCount += iLoadDataTable2D[i, j];
                    xCGTotalLoad += xLoadDataTable2D[i, j] * iLoadDataTable2D[i, j];
                    yCGTotalLoad += yLoadDataTable2D[i, j] * iLoadDataTable2D[i, j];
                    zCGTotalLoad += zLoadDataTable2D[i, j] * iLoadDataTable2D[i, j] + 24 * iLoadDataTable2D[i, j] * iLoadDataTable2D[i, j];

                 
                }
          
            if (iLoadCount > 0)
            {
                posBRTStack();
                UpdateStack();

                xCGTotalLoad /= iLoadCount;
                yCGTotalLoad /= iLoadCount;
                zCGTotalLoad /= iLoadCount;
            }
            else
            {
                xCGTotalLoad = 0;
                yCGTotalLoad = 0;
                zCGTotalLoad = 0;
            }


            //posBRTStack();
            //UpdateStack();

            dWeightTotalLoad = 0.16f * iLoadCount;
            dWeightTotalShip = dWeightTotalLoad + dWeightLightShip;



            xCGTotalShip = (xCGTotalLoad * dWeightTotalLoad + xCGLightShip * dWeightLightShip) / (dWeightTotalShip);
            yCGTotalShip = (yCGTotalLoad * dWeightTotalLoad + yCGLightShip * dWeightLightShip) / (dWeightTotalShip);
            zCGTotalShip = (zCGTotalLoad * dWeightTotalLoad + zCGLightShip * dWeightLightShip) / (dWeightTotalShip);

            // calculate orientation: heel and trim angle
            dKBTVal = Interpolate2D(dWeightTotalShip, 0, dispDataTable1D, heelDataTable1D, kbtDataTable2D);
            dKMTVal = Interpolate2D(dWeightTotalShip, 0, dispDataTable1D, heelDataTable1D, kmtDataTable2D);

            dKBLVal = Interpolate2D(dWeightTotalShip, 0, dispDataTable1D, trimDataTable1D, kblDataTable2D);
            dKMLVal = Interpolate2D(dWeightTotalShip, 0, dispDataTable1D, trimDataTable1D, kmlDataTable2D);


            double BMT = dKMTVal - dKBTVal;
            double BML = dKMLVal - dKBLVal;
            double heel_angle = Math.Atan(yCGTotalShip / BMT) * 180 / Math.PI; // in deg
            double trim_angle = Math.Atan(xCGTotalShip / BML) * 180 / Math.PI; // in deg

            // calculate transverse and longitudinal stability
            //nudInputVal.Value = (decimal)dWeightTotalShip;
            //nudHeelVal.Value = (decimal)(-heel_angle);
            _list = (float)(-heel_angle);
            //nudPitchVal.Value = (decimal)(-trim_angle);
            _tTrim = (float)(-trim_angle);

            CalculateTranverseHydrostatic();
            CalculateLongHydrostatic();

            // show results
            //nudCGTotalLoadX.Value = (decimal)xCGTotalLoad;
            //nudCGTotalLoadY.Value = (decimal)yCGTotalLoad;
            //nudCGTotalLoadZ.Value = (decimal)zCGTotalLoad;
            //nudCGTotalShipX.Value = (decimal)xCGTotalShip;
            //nudCGTotalShipY.Value = (decimal)yCGTotalShip;
            //nudCGTotalShipZ.Value = (decimal)zCGTotalShip;
            //nudContainerCount.Value = iLoadCount;
            //nudDispTotalLoad.Value = (decimal)dWeightTotalLoad;
            //nudDispTotalShip.Value = (decimal)dWeightTotalShip;

            //txbHeelAngle.Text = heel_angle.ToString("F2");
            //txbTrimAngle.Text = trim_angle.ToString("F2");
        }

        #endregion

		


}
