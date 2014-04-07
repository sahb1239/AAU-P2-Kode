﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Test
{
    [TestClass]
    public class XMLParser
    {
        [TestMethod]
        public void JSONNETTester()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<dataroot xmlns:od=\"urn:schemas-microsoft-com:officedata\" generated=\"2011-04-09T18:54:03\">\r\n<BådeSpecifik>\r\n<ID>1</ID>\r\n<Navn>Hajen</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>1</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>2</ID>\r\n<Navn>Gammel. Forellen</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>3</ID>\r\n<Navn>Gedden</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>4</ID>\r\n<Navn>&quot;70&quot;</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>5</ID>\r\n<Navn>Nitte</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>6</ID>\r\n<Navn>Jaguar</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>7</ID>\r\n<Navn>Bøgh</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>8</ID>\r\n<Navn>Sørum</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>9</ID>\r\n<Navn>Maren II</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>10</ID>\r\n<Navn>&quot;85&quot;</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>11</ID>\r\n<Navn>Ørnbo</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>12</ID>\r\n<Navn>Kap 68</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>13</ID>\r\n<Navn>Kap 76</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>14</ID>\r\n<Navn>Kap 80</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>15</ID>\r\n<Navn>Jens &quot;Sigfred&quot;</Navn>\r\n<AntalPladser>2</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>16</ID>\r\n<Navn>Kap 81</Navn>\r\n<AntalPladser>2</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>17</ID>\r\n<Navn>Skrald</Navn>\r\n<AntalPladser>3</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>1</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>18</ID>\r\n<Navn>RB 68</Navn>\r\n<AntalPladser>3</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>1</SpecifikBådType>\r\n<LangtursBåd>1</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>19</ID>\r\n<Navn>&quot;80&quot;</Navn>\r\n<AntalPladser>3</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>20</ID>\r\n<Navn>Kanolle</Navn>\r\n<AntalPladser>3</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>1</SpecifikBådType>\r\n<LangtursBåd>1</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>21</ID>\r\n<Navn>Kap 66</Navn>\r\n<AntalPladser>3</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>22</ID>\r\n<Navn>Aktiv</Navn>\r\n<AntalPladser>3</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>23</ID>\r\n<Navn>Sigfred</Navn>\r\n<AntalPladser>2</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>24</ID>\r\n<Navn>Ajs</Navn>\r\n<AntalPladser>3</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>1</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>25</ID>\r\n<Navn>M.S.</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>26</ID>\r\n<Navn>Langer</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>1</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>27</ID>\r\n<Navn>Laue</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>28</ID>\r\n<Navn>Frem</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>1</SpecifikBådType>\r\n<LangtursBåd>1</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>29</ID>\r\n<Navn>GAR</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>3</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>30</ID>\r\n<Navn>Radiller</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>31</ID>\r\n<Navn>Sejr</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>32</ID>\r\n<Navn>Urban II</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>33</ID>\r\n<Navn>Skjold</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>34</ID>\r\n<Navn>Smækker</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>35</ID>\r\n<Navn>Kap 71</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>36</ID>\r\n<Navn>Erik Hansen</Navn>\r\n<AntalPladser>4</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>37</ID>\r\n<Navn>G.S.</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>1</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>38</ID>\r\n<Navn>Kringeling II</Navn>\r\n<AntalPladser>9</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>39</ID>\r\n<Navn>Kap 67</Navn>\r\n<AntalPladser>9</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>40</ID>\r\n<Navn>Kap 100</Navn>\r\n<AntalPladser>9</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>41</ID>\r\n<Navn>Passiv</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>42</ID>\r\n<Navn>Jubii</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>43</ID>\r\n<Navn>Schölle II</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>44</ID>\r\n<Navn>Bera</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>45</ID>\r\n<Navn>Mini 82</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>3</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>46</ID>\r\n<Navn>Mini 84</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>3</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>47</ID>\r\n<Navn>Berg Back</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>48</ID>\r\n<Navn>Skibswrist</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>49</ID>\r\n<Navn>Forellen</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>50</ID>\r\n<Navn>LÅNT BÅD</Navn>\r\n<AntalPladser>9</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>1</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>51</ID>\r\n<Navn>Kaj Munk</Navn>\r\n<AntalPladser>4</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>52</ID>\r\n<Navn>Ib Stetter</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>1</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>53</ID>\r\n<Navn>Limfjorden ADR lånt</Navn>\r\n<AntalPladser>3</AntalPladser>\r\n<Aktiv>0</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>6</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>54</ID>\r\n<Navn>Aalborg</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>55</ID>\r\n<Navn>Tippy - KAJAK</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>2</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>4</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>56</ID>\r\n<Navn>Terp</Navn>\r\n<AntalPladser>3</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>3</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>57</ID>\r\n<Navn>Støren</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>58</ID>\r\n<Navn>BernHof</Navn>\r\n<AntalPladser>2</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>59</ID>\r\n<Navn>Karpen</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>60</ID>\r\n<Navn>Sej</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>61</ID>\r\n<Navn>Mallima - KAJAK</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>2</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>4</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>62</ID>\r\n<Navn>Arnaq - KAJAK</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>2</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>4</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>63</ID>\r\n<Navn>Papiluk - KAJAK</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>2</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>4</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>64</ID>\r\n<Navn>Malik - KAJAK</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>2</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>4</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>68</ID>\r\n<Navn>LÅNT KAJAK</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>2</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>4</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>69</ID>\r\n<Navn>Ergometer</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>3</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>5</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>70</ID>\r\n<Navn>Ehlers</Navn>\r\n<AntalPladser>3</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>1</SpecifikBådType>\r\n<LangtursBåd>1</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>71</ID>\r\n<Navn>Støckel</Navn>\r\n<AntalPladser>5</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>3</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>72</ID>\r\n<Navn>Hæk</Navn>\r\n<AntalPladser>1</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>3</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>73</ID>\r\n<Navn>Hans Jensen</Navn>\r\n<AntalPladser>2</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>2</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n<BådeSpecifik>\r\n<ID>74</ID>\r\n<Navn>Roar</Navn>\r\n<AntalPladser>3</AntalPladser>\r\n<Aktiv>1</Aktiv>\r\n<BådType>1</BådType>\r\n<Roforbud>0</Roforbud>\r\n<SpecifikBådType>1</SpecifikBådType>\r\n<LangtursBåd>0</LangtursBåd>\r\n</BådeSpecifik>\r\n</dataroot>\r\n";
            var elements = ParseXML<FlereBåde>(xml) as FlereBåde;
            Assert.AreEqual(true, true);
        }

        public T ParseXML<T>(string xml) where T : class
        {
            var reader = XmlReader.Create(new StringReader(xml), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Auto });
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }

        [XmlRoot("dataroot")]
        public class FlereBåde
        {
            [System.Xml.Serialization.XmlElementAttribute("BådeSpecifik")]
            public ARK.Model.Baade[] BådeSpecifik { get; set; }
        }
    }
}
