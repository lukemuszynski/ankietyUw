import { Input, Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { AnswerDto } from '../../models/answerDto';

@Component({
  selector: 'app-questions-user',
  templateUrl: './questions-user.component.html',
  styleUrls: ['./questions-user.component.scss']
})
export class QuestionsUserComponent implements OnInit {

  @Input()
  seriesNumber: number[][];

  @Input()
  token: string;

  answersWithLablesEmocje: AnswerWithLabel[];
  answersWithLabelsRest: AnswerWithLabel[];
  chosenAnswer: number[];


  constructor(private router: Router, private userService: UserService) {
    this.chosenAnswer = [];

    for (let i = 0; i < 15; i++)
      this.chosenAnswer.push(1);

    this.answersWithLablesEmocje = [];
    this.answersWithLablesEmocje.push({ val: 1, label: "Zdecydowanie nie" });
    this.answersWithLablesEmocje.push({ val: 2, label: "Nie" });
    this.answersWithLablesEmocje.push({ val: 3, label: "Tak" });
    this.answersWithLablesEmocje.push({ val: 4, label: "Zdecydowanie tak" });

    this.answersWithLabelsRest = [];
    this.answersWithLabelsRest.push({ val: 1, label: "Nie" });
    this.answersWithLabelsRest.push({ val: 2, label: "Tak" });
  }

  ngOnInit() {

  }

  submitAnswers() {

    let answerDto: AnswerDto = new AnswerDto();
    // this.chosenAnswer;
    //answerDto.answers = this.chosenAnswer;
    answerDto.answers = [];

    for (let i = 0; i < 68; i++) {
      answerDto.answers.push(-1);
    }

    //let j = 0;
    let k = 0;
    console.info(this.chosenAnswer);

    let t = 0;

    for (let i = 0; i < this.seriesNumber[0].length; i++) {

      //numer pytania z emocji
      //this.seriesNumber[0][i]
      let odpowiedzNaIpytanie = this.chosenAnswer[t];
      t++;
      answerDto.answers[this.seriesNumber[0][i]-1] = odpowiedzNaIpytanie;
    }

    for (let i = 0; i < this.seriesNumber[1].length; i++) {

      //numer pytania z emocji
      //this.seriesNumber[0][i]
      let odpowiedzNaIpytanie = this.chosenAnswer[t];
      t++;

      answerDto.answers[this.seriesNumber[1][i]+27] = odpowiedzNaIpytanie;
    }
    for (let i = 0; i < this.seriesNumber[2].length; i++) {

      //numer pytania z emocji
      //this.seriesNumber[0][i]
      let odpowiedzNaIpytanie = this.chosenAnswer[t];
      t++;
      answerDto.answers[this.seriesNumber[2][i]+47] = odpowiedzNaIpytanie;
    }

    console.info(answerDto);
    this.userService.postAnswers(answerDto, this.token).subscribe(res => {
    });

  }

  Emocje: any = {
    "1": "szczęśliwy",
    "2": "niezadowolony",
    "3": "energiczny",
    "4": "zrelaksowany",
    "5": "beczynny",
    "6": "zdenerwowany",
    "7": "bierny",
    "8": "pogodny",
    "9": "napięty",
    "10": "stremowany",
    "11": "niemrawy",
    "12": "zmartwiony",
    "13": "zniecierpliwiony",
    "14": "przygnębiony",
    "15": "śpiący",
    "16": "niespokojny",
    "17": "usatysfakcjonowany",
    "18": "bez pomysłów",
    "19": "smutny",
    "20": "spokojny",
    "21": "aktywny",
    "22": "zadowolony",
    "23": "optymistyczny",
    "24": "przestraszony",
    "25": "cichy",
    "26": "w ponurym nastroju",
    "27": "otępiały",
    "28": "zestresowany"
  }

  Ocb: any = {
    "1": "Pomogłaś/eś komuś w rozwiązaniu problemu w pracy?",
    "2": "Zainteresowałaś/eś się jak inni radzą sobie w pracy?",
    "3": "Zauważyłaś/eś, że współpracownik może popełnić błąd i powiedziałaś/eś mu o tym?",
    "4": "Przejęłaś/eś obowiązki współpracownika?",
    "5": "Pomyślałaś/eś o zmianie pracy?",
    "6": "Zwróciłaś/eś uwagę współpracownikowi, który zachowywał się niewłaściwie?",
    "7": "Szczegółowo zapoznałaś/eś się z informacyjnym e-mailem wysłanym od działu/centrali?",
    "8": "Planujesz zostać po godzinach, aby dokończyć swoją pracę?",
    "9": "Wypełniając swoje obowiązki dałaś/eś z siebie wszystko?",
    "10": "Wytrwale wykonywałaś/eś zadanie pomimo, że było nieprzyjemne/nużące?",
    "11": "Z własnej inicjatywy podjęłaś/eś się pracy, która nie była wymagana?",
    "12": "Poświęciłaś/eś czas na wymyślanie sposobu, który może usprawnić pracę?",
    "13": "Zaproponowałaś/eś nowe rozwiązania, aby ulepszyć jakość pracy działu?",
    "14": "Zamiast szukać winnego, zaproponowałaś/eś konstruktywne rozwiązanie problemu?",
    "15": "Postarałaś/eś się, aby w Twoim dziale panował dobry nastrój?",
    "16": "Załagodziłaś/eś konflikt w zespole?",
    "17": "Dopingowałaś/eś koleżanki i kolegów do lepszej pracy?",
    "18": "Zaangażowałaś/eś się w organizowanie spotkania pracowników firmy?",
    "19": "Wyraziłaś/eś chęć uczestniczenia w spotkaniu pracowników firmy?",
    "20": "Podjęłaś działania na rzecz społeczności firmy?"
  }

  Cwb: any = {
    "1": "Przedłużyłaś/eś sobie przerwę w pracy?",
    "2": "Robiłaś/eś częściej przerwy niż powinnaś/powinieneś?",
    "3": "Pracowałaś/eś wolniej niż powinnaś/powinieneś?",
    "4": "Pracowałaś/eś poniżej swoich możliwości?",
    "5": "Narzekałaś/eś w pracy, bo było ciężko?",
    "6": "Spędzałaś/eś czas w pracy na bujaniu w obłokach?",
    "7": "„Stałaś/eś w cieniu”, aby uniknąć dodatkowej pracy?",
    "8": "Zamierzasz wyjść  z pracy wcześniej bez pytania o pozwolenie?",
    "9": "Spóźniłaś/eś się na umówione spotkanie?",
    "10": "Załatwiałaś/eś swoje własne sprawy bez pozwolenia?",
    "11": "Plotkowałaś/eś na temat współpracowników lub przełożonego?",
    "12": "Powiedziałaś/eś coś nieprzyjemnego współpracownikowi?",
    "13": "Zachowałaś/eś się nieuprzejmie wobec współpracownika?",
    "14": "Odczułaś/eś zazdrość i złość z powodu sukcesów zawodowych współpracowników?",
    "15": "Okłamałaś/eś przełożonego co do ilości lub jakości wykonanej pracy?",
    "16": "Używałaś/eś sprzętu firmowego do prywatnych celów(kopiowanie itp.)?",
    "17": "Nieostrożnie używałaś/eś sprzętu firmowego nie zważając na ewentualne szkody?",
    "18": "Planujesz zabrać do domu drobny sprzęt firmowy?",
    "19": "Zmarnowałaś/eś niepotrzebnie sprzęt firmowy(papier, spinacze, koszulki, itp.)?",
    "20": "Zużyłaś/eś materiały biurowe do prywatnych celów?"
  }

}


class AnswerWithLabel {

  val: number;
  label: string;

}