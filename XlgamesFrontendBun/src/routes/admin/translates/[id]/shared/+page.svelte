<script>
  import SecondaryPage from "$lib/components/pages/SecondaryPage.svelte";
  import QuaternarySection from "$lib/components/sections/QuaternarySection.svelte";
  import PrimaryTextarea from "$lib/components/textarea/PrimaryTextarea.svelte";
  import {getContext} from "svelte";
  import PrimaryCheckbox from "$lib/components/checkbox/PrimaryCheckbox.svelte";
  
  let language = getContext("language")();
</script>

<SecondaryPage title="Общий перевод">
  <QuaternarySection title="Важное">
    <PrimaryTextarea bind:value={language.Shared.Head} title="Метаданные"/>
  </QuaternarySection>
  <QuaternarySection title="Навигационные ссылки">
    <PrimaryTextarea bind:value={language.Shared.GameServers} title="Игровые серверы"/>
    <PrimaryTextarea bind:value={language.Shared.DedicatedServers} title="Выделенные серверы"/>
    <PrimaryTextarea bind:value={language.Shared.ServersWithoutGPU} title="Серверы"/>
    <PrimaryTextarea bind:value={language.Shared.ServersWithGPU} title="Серверы с GPU"/>
    <PrimaryTextarea bind:value={language.Shared.VPS} title="VPS"/>
    <PrimaryTextarea bind:value={language.Shared.WebHosting} title="Веб хостинг"/>
    <PrimaryTextarea bind:value={language.Shared.VPN} title="VPN"/>
    <PrimaryTextarea bind:value={language.Shared.DataCenters} title="Дата центры"/>
    <PrimaryTextarea bind:value={language.Shared.News} title="Новости"/>
    <PrimaryTextarea bind:value={language.Shared.AboutUs} title="О нас"/>
    <PrimaryTextarea bind:value={language.Shared.Contacts} title="Контакты"/>
    <PrimaryTextarea bind:value={language.Shared.TermsService} title="Условия обслуживания"/>
    <PrimaryTextarea bind:value={language.Shared.PrivacyPolicy} title="Политика конфиденциальности"/>
    <PrimaryTextarea bind:value={language.Shared.CookiePolicy} title="Политика «Cookie»"/>
    <PrimaryTextarea bind:value={language.Shared.PersonalAccount} title="Персональный аккаунт"/>
    <PrimaryTextarea bind:value={language.Shared.GameHosting} title="Игровой хостинг"/>
  </QuaternarySection>
  <QuaternarySection title="Ссылки на социальные сети">
    <PrimaryTextarea bind:value={language.Shared.DiscordLink} title="Discord"/>
    <PrimaryTextarea bind:value={language.Shared.FacebookLink} title="Facebook"/>
    <PrimaryTextarea bind:value={language.Shared.InstagramLink} title="Instagram"/>
    <PrimaryTextarea bind:value={language.Shared.SnapchatLink} title="Snapchat"/>
    <PrimaryTextarea bind:value={language.Shared.TelegramLink} title="Telegram"/>
    <PrimaryTextarea bind:value={language.Shared.TwitterLink} title="Twitter"/>
    <PrimaryTextarea bind:value={language.Shared.VkLink} title="VK"/>
    <PrimaryTextarea bind:value={language.Shared.WhatsappLink} title="Whatsapp"/>
  </QuaternarySection>
  <QuaternarySection title="Социальные сети">
    <PrimaryCheckbox bind:value={language.Shared.Discord} title="Discord"/>
    <PrimaryCheckbox bind:value={language.Shared.Facebook} title="Facebook"/>
    <PrimaryCheckbox bind:value={language.Shared.Instagram} title="Instagram"/>
    <PrimaryCheckbox bind:value={language.Shared.Snapchat} title="Snapchat"/>
    <PrimaryCheckbox bind:value={language.Shared.Telegram} title="Telegram"/>
    <PrimaryCheckbox bind:value={language.Shared.Twitter} title="Twitter"/>
    <PrimaryCheckbox bind:value={language.Shared.Vk} title="Vk"/>
    <PrimaryCheckbox bind:value={language.Shared.Whatsapp} title="Whatsapp"/>
  </QuaternarySection>
  <QuaternarySection title="Контакты">
    <PrimaryCheckbox bind:value={language.Shared.PhoneNumber} title="Номер телефона"/>
    <PrimaryCheckbox bind:value={language.Shared.Email} title="Почта"/>
    <PrimaryCheckbox bind:value={language.Shared.OGRNIP} title="ОГРНИП"/>
    <PrimaryCheckbox bind:value={language.Shared.INN} title="ИНН"/>
    <PrimaryCheckbox bind:value={language.Shared.IP} title="ИП"/>
  </QuaternarySection>
  <QuaternarySection title="Продукты">
    <PrimaryTextarea bind:value={language.Shared.Month} title="Месяц"/>
    <PrimaryTextarea bind:value={language.Shared.PriceFrom} title="Цена от"/>
    <PrimaryTextarea bind:value={language.Shared.CurrencySign} title="(Знак валюты)"/>
    <PrimaryCheckbox bind:value={language.Shared.CurrencySignPosition} title="Знак валюты находится перед ценой?"/>
    <PrimaryTextarea bind:value={language.Shared.Order} title="Заказать"/>
    <PrimaryTextarea bind:value={language.Shared.AnyCPU} title="Любой процессор"/>
    <PrimaryTextarea bind:value={language.Shared.AnyGPU} title="Любая видеокарта"/>
    <PrimaryTextarea bind:value={language.Shared.AnyCountry} title="Любая страна"/>
    <PrimaryTextarea bind:value={language.Shared.AnyRegion} title="Любой регион"/>
    <PrimaryTextarea bind:value={language.Shared.CPU} title="Процессор"/>
    <PrimaryTextarea bind:value={language.Shared.GPU} title="Видеокарта"/>
    <PrimaryTextarea bind:value={language.Shared.GHz} title="ГГц"/>
    <PrimaryTextarea bind:value={language.Shared.RAM} title="ОЗУ"/>
    <PrimaryTextarea bind:value={language.Shared.RAMType} title="Тип ОЗУ"/>
    <PrimaryTextarea bind:value={language.Shared.Disk} title="Диск"/>
    <PrimaryTextarea bind:value={language.Shared.DiskType} title="Тип диска"/>
    <PrimaryTextarea bind:value={language.Shared.Country} title="Страна"/>
    <PrimaryTextarea bind:value={language.Shared.Region} title="Регион"/>
    <PrimaryTextarea bind:value={language.Shared.PricePerMonth} title="Цена в месяц от"/>
    <PrimaryTextarea bind:value={language.Shared.Cores} title="Ядер"/>
    <PrimaryTextarea bind:value={language.Shared.Slots} title="Кол-во слотов"/>
    <PrimaryTextarea bind:value={language.Shared.Control} title="Доступ"/>
    <PrimaryTextarea bind:value={language.Shared.GB} title="ГБ"/>
    <PrimaryTextarea bind:value={language.Shared.TB} title="ТБ"/>
    <PrimaryTextarea bind:value={language.Shared.ResetFilters} title="Сбросить фильтры"/>
    <PrimaryTextarea bind:value={language.Shared.ControlPanel} title="Панель управления"/>
    <PrimaryTextarea bind:value={language.Shared.FTP} title="FTP"/>
  </QuaternarySection>
  <QuaternarySection title="Страны">
    <PrimaryTextarea bind:value={language.Shared.Russia} title="Россия"/>
    <PrimaryTextarea bind:value={language.Shared.USA} title="США"/>
    <PrimaryTextarea bind:value={language.Shared.Singapore} title="Сингапур"/>
    <PrimaryTextarea bind:value={language.Shared.Finland} title="Финляндия"/>
    <PrimaryTextarea bind:value={language.Shared.Germany} title="Германия"/>
    <PrimaryTextarea bind:value={language.Shared.France} title="Франция"/>
  </QuaternarySection>
  <QuaternarySection title="Регионы">
    <PrimaryTextarea bind:value={language.Shared.Moscow} title="Москва"/>
    <PrimaryTextarea bind:value={language.Shared.SaintPetersburg} title="Санкт-Петербург"/>
    <PrimaryTextarea bind:value={language.Shared.Orenburg} title="Оренбург"/>
    <PrimaryTextarea bind:value={language.Shared.Ekaterenburg} title="Екатеринбург"/>
    <PrimaryTextarea bind:value={language.Shared.Vladivastok} title="Владивосток"/>
    <PrimaryTextarea bind:value={language.Shared.NewYork} title="Нью-Йорк"/>
    <PrimaryTextarea bind:value={language.Shared.Miami} title="Майами"/>
    <PrimaryTextarea bind:value={language.Shared.LosAngeles} title="Лос-Анджелес"/>
    <PrimaryTextarea bind:value={language.Shared.Hillsboro} title="Хилсборо"/>
    <PrimaryTextarea bind:value={language.Shared.Ashburn} title="Ашберн"/>
    <PrimaryTextarea bind:value={language.Shared.Helsinki} title="Хельсинки"/>
    <PrimaryTextarea bind:value={language.Shared.Falkenstein} title="Фалькенштайн"/>
    <PrimaryTextarea bind:value={language.Shared.Frankfurt} title="Франкфурт"/>
    <PrimaryTextarea bind:value={language.Shared.Nuremberg} title="Нюрнберг"/>
    <PrimaryTextarea bind:value={language.Shared.Gravelines} title="Гравлин"/>
  </QuaternarySection>
  <QuaternarySection title="Континенты">
    <PrimaryTextarea bind:value={language.Shared.Europe} title="Европа"/>
  </QuaternarySection>
  <QuaternarySection title="Остальное">
    <PrimaryTextarea bind:value={language.Shared.More} title="Ещё"/>
    <PrimaryTextarea bind:value={language.Shared.ReadMore} title="Читать ещё"/>
    <PrimaryTextarea bind:value={language.Shared.Error} title="Ошибка"/>
    <PrimaryTextarea bind:value={language.Shared.AnySuggestionsStart} title="Есть предложения? (Начало)"/>
    <PrimaryTextarea bind:value={language.Shared.AnySuggestionsCenter} title="Есть предложения? (Середина)"/>
    <PrimaryTextarea bind:value={language.Shared.AnySuggestionsEnd} title="Есть предложения? (Конец)"/>
    <PrimaryTextarea bind:value={language.Shared.AnyQuestionsStart} title="Есть вопросы? (Начало)"/>
    <PrimaryTextarea bind:value={language.Shared.AnyQuestionsCenter} title="Есть вопросы? (Середина)"/>
    <PrimaryTextarea bind:value={language.Shared.AnyQuestionsEnd} title="Есть вопросы? (Конец)"/>
  </QuaternarySection>
</SecondaryPage>