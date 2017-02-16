import { AnkietyUW.FrontendPage } from './app.po';

describe('ankiety-uw.frontend App', function() {
  let page: AnkietyUW.FrontendPage;

  beforeEach(() => {
    page = new AnkietyUW.FrontendPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
