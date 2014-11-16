using System;

namespace XEP_EsaModelData.Infrastructure
{
    public static class XEP_EmdNames
    {
        // General
        public static readonly string s_KeyID = "ID";
        public static readonly string s_KeyMaterial = "Material";
        public static readonly string s_KeyType = "Type";
        // Needed values
        public static readonly string s_Value_eRsteel = "eRsteel";
        public static readonly string s_Value_ZonePosBefore = "Before";
        public static readonly string s_Value_ZonePosCurrent = "Current";
        public static readonly string s_Value_ZonePosAfter = "After";

        // Cross section
        public static readonly string s_KeyCrossSection = "CrossSection";
        public static readonly string s_KeyGeometry = "Geometry";
        public static readonly string s_KeyComponent = "Component";
        public static readonly string s_KeyShape = "Shape";
        public static readonly string s_KeyPoint = "Point";
        public static readonly string s_KeyPointX = "X";
        public static readonly string s_KeyPointY = "Y";
        public static readonly string s_KeysmallY = "y";
        public static readonly string s_KeysmallZ = "z";
        public static readonly string s_KeyLcs = "LCS";
        public static readonly string s_KeyPrincipal = "Principal";
        public static readonly string s_KeyFibres = "Fibres";
        public static readonly string s_KeyFibre = "Fibre";
        public static readonly string s_KeyFlag = "Flag";
        public static readonly string s_KeySection = "Section";
        public static readonly string s_KeyFormCode = "FormCode";

        // Reinforcement
        public static readonly string s_KeyReinforcement = "Reinforcement";
        public static readonly string s_KeyBar = "Bar";
        public static readonly string s_KeyBarX = "X";
        public static readonly string s_KeyBarY = "Y";
        public static readonly string s_KeyBarD = "D";
        public static readonly string s_KeyBarComponentID = "ComponentID";
        public static readonly string s_KeyBarMaterial = "Material";
        public static readonly string s_KeyBarIsActive = "IsActive";
        public static readonly string s_KeyBarIsDetailing = "IsDetailing";

        // Stirrups
        public static readonly string s_KeyStirrupZone = "StirrupZone";
        public static readonly string s_KeyStirrupZoneID = "ID";
        public static readonly string s_KeyStirrupZoneMaterial = "Material";
        public static readonly string s_KeyStirrupZoneZoneBeg = "ZoneBeg";
        public static readonly string s_KeyStirrupZoneZoneEnd = "ZoneEnd";
        public static readonly string s_KeyStirrupZoneIsAutoCutsCalc = "IsAutoCutsCalc";
        public static readonly string s_KeyStirrupZoneNumCutUser = "NumCutUser";
        public static readonly string s_KeyStirrupZonePosition = "Position";
        public static readonly string s_KeyStirrupZoneCoef = "Coeff_ϕ_m";
        //
        public static readonly string s_KeyStirrup = "Stirrup";
        public static readonly string s_KeyStirrupZoneShape = "StirrupZoneShape";
        public static readonly string s_KeyStirrupBranch = "Branch";
        public static readonly string s_KeyStirrupIsActive = s_KeyBarIsActive;
        public static readonly string s_KeyStirrupIsDetailing = s_KeyBarIsDetailing;
        public static readonly string s_KeyStirrupIsTorsion = "IsTorsion";
        public static readonly string s_KeyStirrupDX = "DX";
        public static readonly string s_KeyStirrupD = "D";
        public static readonly string s_KeyStirrupMultiply = "Multiply";
        public static readonly string s_KeyStirrupDsL = "DsL";
        public static readonly string s_KeyStirrupDsR = "DsR";
        public static readonly string s_KeyStirrupDss = "Dss";
    }
}
