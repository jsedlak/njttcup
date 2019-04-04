import React from 'react';
import { Header, Menu } from '../parts/PageParts';
import './RulesPage.css'

export class RulesPage extends React.Component {
    render() {
        return (
            <div>
                <Header>
                    <Menu />
                </Header>

                <div className="document">
                    <h1>Competition Rules</h1>

                    <h2>Article I. NJBA Time Trial Guidelines Overview</h2>
                    <ol style={{listStyleType: 'lower-alpha'}}>
                        <li> The following Rules & Guidelines have been developed by the NJBA Time Trial Committee for the benefit of our time trial series race promoters and our race participants. The purpose of the Guidelines is to remind both promoters and racers of the important components involved in hosting an NJBA TT Cup Event and of the overall Series. The Time Trial Cup Committee reserves the right to modify or change these Rules, Regulations and Guidelines at any time, in the sole discretion of the Time Trial Cup Committee.</li>

                        <li>Conditions for Participation - By participating in the Time Trial Cup, promoters and racers are hereby agreeing to follow all rules and guidelines, and to pay heightened attention to all suggested items. Any promoter who fails to adhere to the mandatory items shall not be considered for future participation in the TT Cup Series, and may have his race removed from the Series with no advance notice required. Any rider who fails to adhere to these rules may be disqualified from the Series, and prohibited from racing future events in the Series in the current year, or in years subsequent. </li>

                        <li>TT Cup Committee Support – All promoters or racers should feel free to call upon members of the NJBA TT Cup Board if you need any help or support. While the members themselves might not be able to provide the assistance, we have many resources upon which we can call to help resolve situations. This is not to suggest you should be looking at this support option as a first choice in some areas, but use it as necessary. We are all in this together to create top-flight events. </li>
                    </ol>

                    <h2>Article II. TT Cup Committee Contact Info</h2>
                    <p>The TT Cup Committee is comprised of the following Members. You may contact us here (coming soon).</p>
                    <ul>
                        <li>Chuck Crocco</li>
                        <li>Mark Curran</li>
                        <li>Teresa DiSessa</li>
                        <li>Dana Fallon</li>
                        <li>John Sedlak</li>
                        <li>Bob Jaggard</li>
                        <li>Steve Petouvis</li>
                        <li>Tom Mains</li>
                    </ul>

                    {/* ARTICLE III */}
                    <h2>Article III. Rider Qualifications to Participate in the TT Cup</h2>
                    <p>Any rider may participate in the individual time trial events.</p>

                    <p>Out of State riders who are registered on NJBA teams in good standing may compete in the Cup. A rider must have their team designation imprinted on their USAC license, or have a written letter from their Club president stating that the rider is a member of the Club. The rider's Club must be a member in good standing with the NJBA. Good standing includes being fully paid no later than April 15 2019. At that point, if unpaid, no points will be counted toward the Time Trial Cup standings.</p>

                    <p>In the event a rider or club is not in good standing with either the USAC or the NJBA at the time of any race, no points from races where any deficiency existed shall be credited to the rider. It is entirely the responsibility of the rider or the riders' team to ensure they are in good standing with the USAC and the NJBA. There will be no exceptions. Again, please note that no points will be later additionally computed, back credited, or provided for any time period where a deficiency existed or exists. It is the Riders' responsibility to ensure personal and team compliance.</p>

                    <p>All Junior riders will score points in the TT Cup regardless of club/team affiliation.</p>

                    {/* ARTICLE IV */}
                    <h2>Article IV. Race Categories</h2>
                    <p>We have an “A” (Cat 12345) and “B” (Cat 5) for both men and women in the Non TT bike (Eddy) category. Additionally, we have adjusted the Masters categories listed below.</p>

                    <h3>TT Cup Categories</h3>
                    <p>TT Cup Categories will include; Junior Men 9-12; Junior Men 13-14, Junior Men 15-16, Junior Men 17-18, Junior Women 9-14, Junior Women 15-18, Senior Men , Cat 4/5 Men, Masters 45+, Masters 50+, Masters 55+, Masters 60+,Masters 65+, Senior Women, Cat 4/5 Women, Non TT Bike Men Cat 1/2/3/4/5, Non TT Bike Women Cat 1/2/3/4/5, Non TT Bike Men Cat 5 and Non TT Bike Senior Women Cat 5</p>

                    <h3>Non-Aero / Eddy Classification</h3>
                    <p>Non Aero/EDDY Classification riders in this class will compete without Aero Bars or extensions. Disc wheels, spoke covers, and other forms of solid construction “Aero Wheels” such as Trispoke and Spinergy are not permitted. Bicycles shall conform to USAC rules for Mass Start Bicycles. Skinsuits and aero helmets are allowed.</p>

                    <p>For the Non-Aero (Eddy) class, the CUP committee and NJBA Board are concerned that a very small number of riders push the rules and are ignoring the intent of the Eddy class. As we do not wish to burden the class with a large number of regulations, the following guidance to riders is provided:</p>
                    
                    <ol>
                        <li>Riders participating in non-aeroTT class are expected to utilize standard road racing equipment. While aero bikes are permitted, purpose built or modified aero-road equipment is not encouraged. Failure of riders to respect the intention of the Non-Aero/Eddy classification will result in the committee implementing and enforcing new rules to limit the effect of equipment on this class. Such rules, if needed, may be implemented at any time during the season by either the TT Cup Committee or the NJBA Board.</li>

                        <li>The use of accessory equipment solely to provide an aero advantage or to aid a rider in maintaining an aero position is forbidden. Such accessories include but are not limited to: (a) excessive handlebar padding, (2) arm pads or forearm padding in clothing, (c) forward computer mounts or other accessories which can be utilized as a gripping surface. Riders observed utilizing accessories as gripping surfaces to attain an aero position will be disqualified from the nonaero TT CUP class.</li>

                        <li>All prior rules remain in effect for the non-aero class.</li>
                    </ol>

                    <p>Other than at the NJITT, promoters must ensure that they have, at minimum, the abovementioned categories in all their events. This is a condition to being a promoting event in our TT Cup Series. The above categories must be provided, with no exceptions or changes so participating athletes can properly score points for the TT Cup categories in which they are competing. Promoters may add additional categories if they desire as long as all the categories noted above are present.</p>

                    {/* RACE ITEMS */}
                    <h2>Article V. Race Items</h2>
                    <h3>2019 Cup Calendar</h3>
                    <p>The 2019 Cup Calendar can be found on the <a href="/schedule">Schedule</a> page.</p>

                    <h3>Scoring</h3>
                    <p>All races will be weighted equally.</p>
                    <p>Points will be allotted from 20-1 for places 1-20.</p>

                    <p>If fewer than 20 riders participate in any event category, the points awarded shall remain unchanged and awarded as noted below for all participating riders who participate and score in the race. </p>

                    <p>In the event of a tie score/time as determined by the USAC officials, the TT Cup points awarded for such placings representing the tied riders shall be aggregated and shared evenly amongst the tied riders. To score, a rider must not only register and start a race, but must also finish and be given a scored time. Any rider who “does not start”(DNS) or “does not finish” (DNF) shall not be awarded any points irrespective if the promoter includes the riders or bib number on the scoring sheets. A rider must finish with a scored time to be awarded TT Cup points.</p>

                    <h3>Junior Classes Excluded from Flanders and High Point</h3>
                    <p>The promoters and townships involved have requested that Junior classes be excluded from the High Point and Flanders Time Trials for safety reasons. Thus, the Junior riders will have two less events comprising their TT Cup calendar (Their season will be 11 races with 2 drops). Again, to restate this important point, no Junior classes will be included at High Point or Flanders, and thus accordingly, no Junior shall receive any points for these events in those categories. Thus, Juniors will have a calendar equaling two less events than the adult categories. </p>

                    <h3>Out of State Riders May Compete in the Cup</h3>
                    <p>The TT Cup will allow point scoring from “out of state” riders who are registered on NJBA teams in good standing. It is the intent of the NJ Time Trial Cup Committee to attract more riders to our Series, and to preserve its appeal for years to come.</p>

                    <h3>Event Category Registration</h3>
                    <p>At each race that is part of the TT Cup, all riders competing for the TT Cup Series must register in their respective TT Cup category at each race comprising the TT Cup with the possible exception of the New Jersey Individual Time Trial Championships, as noted below. </p>

                    <h3>Aero State Time Trial</h3>
                    <p>For 2019 State Aero TT the following clarifications are made:</p>
                    <ol>
                        <li>The NJBA will support five (5) year age groups for both Men and Women Masters. To qualify for a State Championship award, riders are required to race either their age group or Open (senior).</li>

                        <li>If registration for any one age group does not meet a minimum of three (3) riders, that specific age group will be combined with the next younger age group for the purposes of designating a state champion. This rule may be waived for one or more age groups at the discretion of the NJBA Board with notification to riders prior to the event.</li>

                        <li>Due to USAC's regulations regarding State Championships, there is no Category 4/5 State Championship field at the NJITT. For the purpose of TT CUP points, cat 4/5 riders will be permitted to ride in Open (senior) or their appropriate master’s age group. To determine TT CUP points, ALL cat 4/5 riders participating in the State Championship race regardless of group raced will be listed by time and CUP points assigned from that inclusive list of cat 4/5 racers.</li>
                    </ol>

                    <h3>Non-Aero / Eddy State Championship</h3>
                    <p>The EDDY is a non-standard, non- USA Cycling championship held by the NJBA to benefit our racers. The Eddy will be conducted utilizing the NJBA TT CUP non-aero rules with age groups at the discretion of both the NJBA and the EDDY promoter.</p>

                    <h3>Tie Breaker at Season End</h3>
                    <p>At season-end, in the event there are riders in the same Cup classification with the same number of total points, then ties are broken by totaling the number of 1st place finishes, then 2nd place finishes, then 3rd place finishes, etc. until a clear winner is established. This will apply to all categories in the NJ Time Trial Cup.</p>

                    <h3>Mandatory Dropped Race or Races</h3>
                    <p>For the 2019 season, we will have eleven (11) events with the lowest 2 scores dropped. In determining the final computation of the TT Cup Series total points for each rider, the final computation as performed by the TT Cup Committee shall require that each rider mandatorily drop the riders’ lowest 2 scores as noted below. This dropped scores shall be “dropped” at season end in the final computation by the TT Cup Committee.</p>

                    <p>The term Lowest Score shall be deemed to include any race where a rider in fact completes the race and receives a placing or score or Cup points, as well as any race in which a rider started but “Did Not Finish”, or any race in which a rider “Did not Start”, or any race in which a rider failed to register and compete. Hence, a rider need not race a race to drop that particular race. Thus, a DNS, DNF or Failed to Register/Compete shall be considered “scores” for the sake of the mandatory dropping of scores as noted below. </p>

                    {/* ARTICLE VI */}
                    <h2>Article VI. Additional Promoter Requirements</h2>
                    <p>All Promoters hereby agree to promote and put forth their time trials in line with the Rules and Regulations contained here; In the event a Promoter or Race fails to adhere to these Rules and Regulations, the Time Trial Cup Committee reserves its right to immediately withdraw any such even from the TT Cup Series, at any time.</p>

                    <p><strong>Pre-registration</strong> - We strongly recommend limited registration to preregistration in advance of the race, avoiding any same-day registrations.</p>

                    <p>Unless an exception is permitted by the TT Cup Committee, online Registration must remain open at least until Wednesday preceding the event, until at least 9 pm at night. A promoter may leave registration open longer or later in the week as long as they can properly handle their back office and other administrative responsibilities so as to comply with our other requirements herein. </p>

                    <p><strong>New Events</strong> – For any promoter wishing consideration in the TT Cup Series they shall exhibit proficiency in running an event one year before Cup status can be granted.</p>

                    <p><strong>Refunds or Rain dates</strong> - In the event a race is cancelled in whole, or in part, for no fault of the riders, then the promoter must reimburse all riders their entire entry fee or provide notice in advance of rain (reschedule) date for the event. If no rain date is provided in advance, and the event is not rescheduled, then the promoters must refund entry fee monies to riders within a reasonable number of days subsequent to the cancelled event. If the event can be rescheduled to a suitable date, with adequate notice to riders, the TT Cup Committee reserves the right to keep the race in the Series. If deemed unreasonable, or unfair to the riders, the event will be dropped from the Series. This is a decision that will be made by the TT Cup Committee, in conjunction with the promoter and NJBA</p>

                    <p><strong>USAC Regulations</strong> – Promoters may not impose any bike or equipment standards (such as prohibiting disc wheels or aero helmets), without getting advance permission from the TT Cup Committee. Promoters must advise and receive permission from the TT Cup Committee if their race is not USAC conforming. For example, if a promoter is going to prohibit the use of aero bar extensions, this must be a) disclosed to the TT Cup Committee in advance and receive TT Cup approval, and b) be clearly presented on preregistration and other marketing materials so all riders are aware of the condition. Otherwise, all USAC regulations pertaining to bicycle equipment, clothing and other regulations shall be controlling.</p>

                    <p><strong>Note the following USAC Rules for riders 14 and under</strong></p>
                    <ol>
                        <li>Riders 14 and under are restricted to massed-start bicycles in all events, including time trials.</li>
                        <li>A massed-start bicycle is a road or track bicycle that is legal in all events within the road or track discipline, rather than a bicycle that is restricted to particular events. Handlebars for massed-start bicycles may not have forearm supports nor handlebar extensions or attachments that point forward</li>
                    </ol>

                    <p><strong>Start Order &amp; Numbering</strong> – Will be at the Promoter’s discretion. Promoters will make every effort to keep race categories together for continuity. However, a promoter does reserve the right to make appropriate start order changes that may be necessary that day for volunteers, etc., and/or to keep the flow of the race appropriate.</p>

                    <p><strong>Pre-Registration Only</strong> - Riders shall be eligible for TT CUP points only in the category in which they pre-registered. With respect to Cup Points, no changes to classification will be permitted after start times are posted.</p>

                    <p><strong>Time Gaps</strong> - Promoters should have time gaps no less than 30 seconds. Suggestion: promoters will help themselves if, when creating start lists, they put a few (2 recommended) 30 second “blank slots” in between categories. This will help create a cushion and separate categories and avoid, for example, a junior being too overrun by a faster rider behind. As well, those gaps will ensure that if you’ve missed anyone, or have to make a race-day addition or exception, you have some slots you can fill last minute. </p>

                    <p><strong>Time keeping / Scoring</strong> - This item is one of the most critical items. In all situations, Promoters must use some form of Electronic timing or scoring, as best possible to ensure accurate and timely results. This would include use of a spreadsheet program into which rider start and finish times shall be inputted, and the program shall generate computed times and scoring. While manual-scoring sheets may, and should, be maintained by race officials or timing persons as backup, as a failsafe in the event of a technical failure, the promoter must utilize an electronic, spreadsheet, database-type system. ** The NJBA TT Cup Committee can refer promoters to parties who can handle the electronic scoring for minimal monies. The TT Cup Committee reserves the right to require proof of such timing or scoring before including the event in the Series. </p>

                    <p><strong>DNS and DNF</strong> – TT Cup points are only awarded to riders who start a race and finish a race. If a rider starts but “does not finish”, or registers but “does not start”, then that rider shall not be awarded TT Cup Series points. As such, all race promoters must clearly notate any registered rider who either a) does not start, b) does not finish or c) does not get a scored time for any other reason. We ask that any riders who do not start or do not finish have their scores on the final scoring sheet properly notated with DNS or DNF notations.</p>

                    <p><strong>Results, Protests</strong> - Promoters should strive to quickly present correct and timely results in initial draft form, then, after presenting “FINAL” results. Subsequent to posting “Final” results, there shall be a 15minute protest period during which riders or officials may modify and correct results. After the 15minute protest period has elapse, if no further disputes or issues have been presented, then the results become final and nonappealable. Promoters shall ensure they announce loudly that results are posted, and notate the beginning of the 15-minute appeal period.</p>

                    <p>No Promoter shall, subsequent to the protest period, modify any results whatsoever without advising the NJ TT Cup of such a proposed change and receiving the TT Cup’s permission to modify such results. The rationale for this is that each race has a significant and material impact on the TT Cup Series points that a rider attains. A rider in the Cup chase has an expectation of knowing that, once the 15 minutes have elapsed, they can leave the race without worry that the results, and Cup points earned, will not change without their being present to defend their points and position.</p>

                    <p><strong>Residual Issues, Disputes, and Appeals</strong> - Promoters shall record and memorialize any issues with scoring or disputes, and shall forward to the NJ TT Cup an electronic copy of the final results and placings. The Final results must be sent to the Time Trial Cup within 48 hours of the end of the event.</p>

                    <p><strong>Submission of Results</strong> - Promoters must provide an electronically formatted list that includes both ALL registered riders and final results to the TT Cup Committee no later than 2 days after the event. Please make note of this change from years past in which only final results were required to be submitted. The results must be in electronic format, such as Microsoft Excel, with all the following fields in the results file:</p>

                    <ul>
                        <li>Rider First Name</li>
                        <li>Rider Last Name</li>
                        <li>USAC License Number</li>
                        <li>Team</li>
                        <li>Category</li>
                        <li>Place/result within Category</li>
                        <li>Time</li>
                    </ul>

                    <p><strong>Start Line</strong> - The promotes must provide a rider holder to hold riders at the start time; this must be provided, other than in the Team time trial events or Team time trial categories. </p>

                    <p><strong>Marshalling</strong> - the Promoter shall provide sufficient and ample marshals to ensure a safe and proper event; Marshalls should be provided with orange vests and cones, and instructed as to how to properly flag/point riders thru turns, and where to stand to marshal properly; No material intersection or turn can be without a marshal protecting the rider’s safety. Promoters will ensure they spend time with the marshals explaining proper technique for waiving riders thru turns or around cones.</p>

                    <p><strong>Turn around Signage, Cone, and Finish Line</strong> - Promoters shall post at minimum of 1 (one) sign/advisory stating the distance to the turn-around cone (if any), approximately 500meters from the turn around, stating the distance to the turn around. A Turn around cone shall be designated by a single orange “large” or other highly visible cone, with a “turn around marshal” adjacent to the cone advising riders to turn.</p>

                    <p><strong>Finish Line</strong> - Promoters shall post a sign/advisory no less than 500 meters from the finish line, stating the distance to the finish. The finish shall be clearly marked by a line, or tape, across the road, as well as an orange cone positioned directly on the finishing line, on the side of the road. </p>

                    {/* ARTICLE VII */}
                    <h2>Article VII. Mandatory use of the TT Cup Logo</h2>
                    <p>The promoter shall include the NJBA TT Cup Logo on the promoters BikeReg or other registration website; on the Promoters’ Club’s website if such a website is maintained where the race is presented and discuss; on any and all other materials where the race is presented, marketed, promoted or discussed. It shall be a small logo that shall designate the race as part of the Series. The logo shall be provided to the promoters in the coming months. It will not be obtrusive.</p>

                    {/* EXTRA */}
                    <h2>USA Cycling and the U.S. Anti- Doping Agency</h2>
                    <p>In order to maintain a level, drug free racing environment, we work closely with the U.S. Anti- Doping Agency (USADA) to implement a robust athlete testing program that includes all levels of competition, as well as out of competition testing. Therefore, it is important for you to remember that as a member of USA Cycling, you could be subject to testing by USADA at any time during our Cup series, with, or without notice.</p>
                </div>
            </div>
        )
    }
}