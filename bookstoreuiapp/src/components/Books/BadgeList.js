import GenreBadge from './Badges/GenreBadge';
import FormatBadge from './Badges/FormatBadge';
import TextSearchBadge from './Badges/TextSearchBadge';

const BadgeList = () => {
    return(<div className='d-flex flex-wrap'>
                <TextSearchBadge />
                <GenreBadge />
                <FormatBadge />
            </div>)
}

export default BadgeList;