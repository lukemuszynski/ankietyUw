import {TestTimeDto} from "./testTimeDto";

export class CreateTestDto{
    firstQuestionAddSeconds: number;
    secondQuestionAddSeconds: number;
    thirdQuestionAddSeconds: number;
    fourthQuestionAddSeconds: number;
    testTimes: TestTimeDto[];
    timeToFillTestAddSeconds: number;
}