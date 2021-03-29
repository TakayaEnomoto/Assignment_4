using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    //Character class for character generation
    public class Character
    {
        public string name;
        public int str;
        public int tough;
        public int dex;
        public int iq;
        public int pow;
        public int chr;
        public int hp;
        public int sp;
    }

    private TMP_InputField strength;
    private TMP_InputField toughness;
    private TMP_InputField dexterity;
    private TMP_InputField IQ;
    private TMP_InputField power;
    private TMP_InputField charm;
    private TMP_InputField HP;
    private TMP_InputField SP;
    private TMP_InputField characterName;
    private TextMeshProUGUI warning;
    private List<Character> characterList;//List of generated characters, which cannot be changed.
    private List<string> charactNameList;//List of character names that adds into dropdown.
    TMP_Dropdown m_Dropdown;//Character dropdown

    void Start()
    {
        //Get all the components
        m_Dropdown = GameObject.Find("CharacterList").GetComponent<TMP_Dropdown>();
        charactNameList = new List<string>();
        characterList = new List<Character>();
        strength = GameObject.Find("Strength").GetComponent<TMP_InputField>();
        toughness = GameObject.Find("Toughness").GetComponent<TMP_InputField>();
        dexterity = GameObject.Find("Dexterity").GetComponent<TMP_InputField>();
        IQ = GameObject.Find("IQ").GetComponent<TMP_InputField>();
        power = GameObject.Find("Power").GetComponent<TMP_InputField>();
        charm = GameObject.Find("Charm").GetComponent<TMP_InputField>();
        HP = GameObject.Find("HP").GetComponent<TMP_InputField>();
        SP = GameObject.Find("SP").GetComponent<TMP_InputField>();
        characterName = GameObject.Find("Name").GetComponent<TMP_InputField>();
        warning = GameObject.Find("Warning").GetComponent<TextMeshProUGUI>();
    }

    //While pressing the "random" button, random a character, except name.
    public void RandomCharacter()
    {
        strength.text = Random.Range(1, 21).ToString();
        toughness.text = Random.Range(1, 21).ToString();
        dexterity.text = Random.Range(1, 21).ToString();
        IQ.text = Random.Range(1, 21).ToString();
        power.text = Random.Range(1, 21).ToString();
        charm.text = Random.Range(1, 21).ToString();
        //Change the hp and sp, otherwise it's not gonna change automatically.
        HP.text = (int.Parse(toughness.text) * 2).ToString();
        SP.text = (int.Parse(IQ.text) * 2).ToString();
    }

    //Function that is related with the character dropdown. It calls out the generated character's infomation if a character in the drop down is choosen.
    public void SelectCharacter()
    {
        characterName.text = characterList[m_Dropdown.value].name;
        strength.text = characterList[m_Dropdown.value].str.ToString();
        toughness.text = characterList[m_Dropdown.value].tough.ToString();
        dexterity.text = characterList[m_Dropdown.value].dex.ToString();
        IQ.text = characterList[m_Dropdown.value].iq.ToString();
        power.text = characterList[m_Dropdown.value].pow.ToString();
        charm.text = characterList[m_Dropdown.value].chr.ToString();
        HP.text = characterList[m_Dropdown.value].hp.ToString();
        SP.text = characterList[m_Dropdown.value].sp.ToString();
    }

    //While pressing the "Generate" button, generate the character if all the input fields are filled with something.
    public void GenerateCharacter()
    {
        if(strength.text !="" && toughness.text != "" && dexterity.text != "" && IQ.text != "" && power.text != "" && charm.text != "" && characterName.text != "")
        {
            Character character = new Character();
            character.str = int.Parse(strength.text);
            character.tough = int.Parse(toughness.text);
            character.dex = int.Parse(dexterity.text);
            character.iq = int.Parse(IQ.text);
            character.pow = int.Parse(power.text);
            character.chr = int.Parse(charm.text);
            character.hp = int.Parse(HP.text);
            character.sp = int.Parse(SP.text);
            character.name = characterName.text;
            Debug.Log(charm.text.ToString());
            charactNameList.Add(character.name);
            characterList.Add(character);
            m_Dropdown.ClearOptions();
            m_Dropdown.AddOptions(charactNameList);
        }
        else
        {
            StartCoroutine(WarnAndDisappear());
        }
    }

    //Tell the player to fill all the blanks before generate a character;
    IEnumerator WarnAndDisappear()
    {
        warning.text = "Fill all the blanks!!!";
        yield return new WaitForSeconds(1.5f);
        warning.text = "";
    }
}
